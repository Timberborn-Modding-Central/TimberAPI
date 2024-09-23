using Timberborn.Persistence;
using Timberborn.ToolSystem;
using TimberbornBuilderPriorityToolFactory = Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

public class BuilderPriorityToolFactory(TimberbornBuilderPriorityToolFactory builderPriorityToolFactory)
    : BaseToolFactory<BuilderPriorityToolToolInformation>
{
    public override string Id => "PriorityTool";

    protected override Tool CreateTool(ToolSpecification toolSpecification,
        BuilderPriorityToolToolInformation toolInformation, ToolGroup? toolGroup)
    {
        var priorityTool = builderPriorityToolFactory.Create(toolInformation.Priority);
        priorityTool.ToolGroup = toolGroup;

        return priorityTool;
    }

    protected override BuilderPriorityToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
    {
        return new BuilderPriorityToolToolInformation(objectLoader.Get(new PropertyKey<string>("Priority")));
    }
}