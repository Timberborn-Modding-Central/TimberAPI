using System;
using System.Collections.Generic;

namespace TimberApi.Internal.Common
{
    public static class TopologicalSortingExtensions
    {
        public static IEnumerable<T> TopogicalSequenceDfs<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> deps)
        {
            HashSet<T> yielded = new HashSet<T>();
            HashSet<T> visited = new HashSet<T>();
            Stack<KeyValuePair<T, IEnumerator<T>>> stack = new Stack<KeyValuePair<T, IEnumerator<T>>>();

            foreach (T t in source)
            {
                stack.Clear();
                if (visited.Add(t))
                    stack.Push(new KeyValuePair<T, IEnumerator<T>>(t, deps(t).GetEnumerator()));

                while (stack.Count > 0)
                {
                    var p = stack.Peek();
                    bool depPushed = false;
                    while (p.Value.MoveNext())
                    {
                        var curr = p.Value.Current;
                        if (visited.Add(curr))
                        {
                            stack.Push(new KeyValuePair<T, IEnumerator<T>>(curr, deps(curr).GetEnumerator()));
                            depPushed = true;
                            break;
                        }
                        else if (!yielded.Contains(curr))
                            throw new Exception("cycle");
                    }

                    if (!depPushed)
                    {
                        p = stack.Pop();
                        if (!yielded.Add(p.Key))
                            throw new Exception("bug");
                        yield return p.Key;
                    }
                }
            }
        }
    }
}