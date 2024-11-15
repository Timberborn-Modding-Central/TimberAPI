using System;
using System.Collections.Generic;
using System.Linq;
using TimberApi.DependencyContainerSystem;
using TimberApi.SingletonSystem;
using Timberborn.Persistence;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.GenericTool;

public class GenericToolFactory : BaseToolFactory<GenericToolToolInformation>, IEarlyLoadableSingleton
{
    private readonly PropertyKey<string> _classnameKey = new("ClassName");
    
    public override string Id => "GenericTool";

    private List<Type> _toolTypes = null!;

    protected override Tool CreateTool(ToolSpecification toolSpecification, GenericToolToolInformation toolInformation, ToolGroup? toolGroup)
    {
        if (DependencyContainer.GetInstance(GetTypeFromName(toolInformation.ClassName)) is not Tool tool)
        {
            throw new Exception($"GenericToolFactory could not find the Tool {toolInformation.ClassName}");
        }
        
        tool.ToolGroup = toolGroup;

        return tool;
    }

    protected override GenericToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
    {
        return new GenericToolToolInformation(objectLoader.Get(_classnameKey));
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