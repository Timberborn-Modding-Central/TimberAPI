using System;
using System.Collections.Generic;

namespace TimberApi.Common.Helpers
{
    /// <summary>
    ///     https://stackoverflow.com/a/51235189/10082425
    /// </summary>
    public static class Sorters
    {
        public static IEnumerable<T> TopologicalSequence<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> deps)
        {
            var yielded = new HashSet<T>();
            var visited = new HashSet<T>();
            var stack = new Stack<Tuple<T, IEnumerator<T>>>();

            foreach (var t in source)
            {
                stack.Clear();
                if (visited.Add(t))
                {
                    stack.Push(new Tuple<T, IEnumerator<T>>(t, deps(t).GetEnumerator()));
                }

                while (stack.Count > 0)
                {
                    var p = stack.Peek();
                    var depPushed = false;
                    while (p.Item2.MoveNext())
                    {
                        var curr = p.Item2.Current;
                        if (visited.Add(curr))
                        {
                            stack.Push(new Tuple<T, IEnumerator<T>>(curr, deps(curr).GetEnumerator()));
                            depPushed = true;
                            break;
                        }

                        if (! yielded.Contains(curr))
                        {
                            throw new Exception("cycle");
                        }
                    }

                    if (depPushed)
                    {
                        continue;
                    }


                    p = stack.Pop();
                    if (! yielded.Add(p.Item1))
                    {
                        throw new Exception("bug");
                    }

                    yield return p.Item1;
                }
            }
        }
    }
}