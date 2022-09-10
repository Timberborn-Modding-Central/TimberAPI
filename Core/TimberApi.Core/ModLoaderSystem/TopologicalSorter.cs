using System;
using System.Collections.Generic;
using TimberApi.New.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    /// <summary>
    ///     https://stackoverflow.com/a/51235189/10082425
    /// </summary>
    internal class TopologicalSorter : IModDependencySorter
    {
        public IEnumerable<IMod> Sort(IEnumerable<IMod> source, Func<IMod, IEnumerable<IMod>> dependencies)
        {
            HashSet<IMod> yielded = new();
            HashSet<IMod> visited = new();
            Stack<KeyValuePair<IMod, IEnumerator<IMod>>> stack = new();

            foreach (IMod t in source)
            {
                stack.Clear();
                if (visited.Add(t))
                {
                    stack.Push(new KeyValuePair<IMod, IEnumerator<IMod>>(t, dependencies(t).GetEnumerator()));
                }

                while (stack.Count > 0)
                {
                    KeyValuePair<IMod, IEnumerator<IMod>> p = stack.Peek();
                    var depPushed = false;
                    while (p.Value.MoveNext())
                    {
                        IMod? curr = p.Value.Current;
                        if (visited.Add(curr))
                        {
                            stack.Push(new KeyValuePair<IMod, IEnumerator<IMod>>(curr, dependencies(curr).GetEnumerator()));
                            depPushed = true;
                            break;
                        }

                        if (!yielded.Contains(curr))
                        {
                            throw new Exception("cycle");
                        }
                    }

                    if (!depPushed)
                    {
                        p = stack.Pop();
                        if (!yielded.Add(p.Key))
                        {
                            throw new Exception("bug");
                        }

                        yield return p.Key;
                    }
                }
            }
        }
    }
}