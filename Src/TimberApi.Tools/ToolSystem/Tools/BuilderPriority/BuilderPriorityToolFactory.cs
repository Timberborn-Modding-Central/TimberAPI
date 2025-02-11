using Timberborn.ToolSystem;
using UnityEngine;
using TimberbornBuilderPriorityToolFactory = Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

public class BuilderPriorityToolFactory(TimberbornBuilderPriorityToolFactory builderPriorityToolFactory) : IToolFactory
{
    public string Id => "PriorityTool";
    
    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null)
    {
        var builderPriorityToolSpec = toolSpec.GetSpec<BuilderPriorityToolSpec>();
        
        Debug.LogWarning("I AM RUNNING");
        var priorityTool = builderPriorityToolFactory.Create(builderPriorityToolSpec.Priority);
        priorityTool.ToolGroup = toolGroup;
        Debug.LogWarning("AM I FINISHING?");

        return priorityTool;
    }
}