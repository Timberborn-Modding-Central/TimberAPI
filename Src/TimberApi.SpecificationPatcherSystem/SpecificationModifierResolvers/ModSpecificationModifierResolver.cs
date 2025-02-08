using System;
using System.Linq;
using Timberborn.Modding;

namespace TimberApi.SpecificationPatcherSystem.SpecificationModifierResolvers;

public class ModSpecificationModifierResolver(ModRepository modRepository) : ISpecificationModifierResolver
{
    public string Modifier => "mod";
    
    public bool Resolve(string argument)
    {
        return modRepository.EnabledMods.Any(mod => string.Equals(mod.Manifest.Id, argument, StringComparison.CurrentCultureIgnoreCase));
    }
}