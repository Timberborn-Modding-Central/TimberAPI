using System;
using System.Collections.Generic;
using System.Linq;
using TimberApi.DependencyContainerSystem;
using TimberApi.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.GenericTool;

public class GenericToolFactory : IToolFactory, IEarlyLoadableSingleton
{
    public string Id => "GenericTool";
    
    private List<Type> _toolTypes = null!;
    
    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null)
    {
        var genericToolSpec = toolSpec.GetSpec<GenericToolSpec>();
        
        if (DependencyContainer.GetInstance(GetTypeFromName(genericToolSpec.ClassName)) is not Tool tool)
        {
            throw new Exception($"GenericToolFactory could not find the Tool {genericToolSpec.ClassName}");
        }
        
        tool.ToolGroup = toolGroup;

        return tool;
    }

    public void EarlyLoad()
    {
        _toolTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => t.IsSubclassOf(typeof(Tool)))
            .ToList();
    }
    
    private Type GetTypeFromName(string classNameOrFullName)
    {
        return _toolTypes.SingleOrDefault(type => type.FullName == classNameOrFullName || type.Name == classNameOrFullName) ?? throw new Exception($"GenericToolFactory could not find the Tool {classNameOrFullName}");
    }
}