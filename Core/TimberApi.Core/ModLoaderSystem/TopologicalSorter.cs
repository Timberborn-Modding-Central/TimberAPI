using System;
using System.Collections.Generic;
using TimberApi.Core2.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class TopologicalSorter : IModDependencySorter
    {
        public IEnumerable<IMod> Sort(IEnumerable<IMod> source, Func<IMod, IEnumerable<IMod>> dependencies)
        {
            HashSet<IMod> yielded = new HashSet<IMod>();
            HashSet<IMod> visited = new HashSet<IMod>();
            Stack<KeyValuePair<IMod, IEnumerator<IMod>>> stack = new Stack<KeyValuePair<IMod, IEnumerator<IMod>>>();

            foreach (IMod t in source)
            {
                stack.Clear();
                if (visited.Add(t))
                    stack.Push(new KeyValuePair<IMod, IEnumerator<IMod>>(t, dependencies(t).GetEnumerator()));

                while (stack.Count > 0)
                {
                    var p = stack.Peek();
                    bool depPushed = false;
                    while (p.Value.MoveNext())
                    {
                        var curr = p.Value.Current;
                        if (visited.Add(curr))
                        {
                            stack.Push(new KeyValuePair<IMod, IEnumerator<IMod>>(curr, dependencies(curr).GetEnumerator()));
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