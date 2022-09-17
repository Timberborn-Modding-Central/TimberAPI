using System.Collections.Immutable;
using System.Reflection;

namespace TimberApi.ModSystem
{
    public interface IModRepository
    {
        ImmutableArray<IMod> All();

        ImmutableArray<IMod> GetCodeMods();

        bool TryGetByUniqueId(string uniqueId, out IMod mod);

        bool TryGetByAssembly(Assembly assembly, out IMod mod);
    }
}