using System;
using System.Collections.Generic;
using TimberApi.Core2.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    public interface IModDependencySorter
    {
        IEnumerable<IMod> Sort(IEnumerable<IMod> source, Func<IMod, IEnumerable<IMod>> dependencies);
    }
}