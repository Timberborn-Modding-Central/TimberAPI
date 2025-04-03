using Timberborn.BlueprintSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class BlueprintExtensionHelper
{
    public static AdvancedDeserializer AdvancedDeserializer;

    public BlueprintExtensionHelper(AdvancedDeserializer advancedDeserializer)
    {
        AdvancedDeserializer = advancedDeserializer;
    }
}

public static class BlueprintExtensions
{
    public static T GetSpecOrDefault<T>(this ComponentSpec componentSpec) where T : ComponentSpec, new()
    {
        var result = componentSpec.GetSpec<T>();

        if (result != null)
        {
            return result;
        }
        
        return new T();
    }
    
}