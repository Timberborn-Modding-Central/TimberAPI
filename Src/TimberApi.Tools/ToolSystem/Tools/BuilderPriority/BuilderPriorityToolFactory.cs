using System;
using Timberborn.PrioritySystem;
using Timberborn.ToolSystem;
using TimberbornBuilderPriorityToolFactory = Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

public class BuilderPriorityToolFactory(TimberbornBuilderPriorityToolFactory builderPriorityToolFactory) : IToolFactory
{
    public string Id => "PriorityTool";
    
    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null)
    {
        var builderPriorityToolSpec = toolSpec.GetSpec<PriorityToolSpec>();

        Enum.TryParse(builderPriorityToolSpec.Priority, out Priority priority);
        
        var priorityTool = builderPriorityToolFactory.Create(priority);
        priorityTool.ToolGroup = toolGroup;

        return priorityTool;
    }
}