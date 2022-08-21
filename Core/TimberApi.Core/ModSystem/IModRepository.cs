using System.Collections.Immutable;
using System.Reflection;

namespace TimberApi.Core.ModSystem
{
    public interface IModRepository
    {
        ImmutableArray<IMod> All();

        bool TryGetByUniqueId(string uniqueId, out IMod? mod);

        bool TryGetByAssembly(Assembly assembly, out IMod mod);
    }
}