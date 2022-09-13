using System;
using System.Collections.Generic;
using TimberApi.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    internal interface IModDependencySorter
    {
        IEnumerable<IMod> Sort(IEnumerable<IMod> source, Func<IMod, IEnumerable<IMod>> dependencies);
    }
}