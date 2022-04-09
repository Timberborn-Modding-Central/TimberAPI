using System;
using Timberborn.ToolSystem;

/**
 * This is for any other code that isn't TimberAPI, but you can 
 * do directly with Timberborn code
 * 
 * More examples to come
 */
namespace TimberAPIExample.Examples.GameExamples
{
    /**
     * Example use of localization label in a ToolGroup
     * This label was added in Awake()
     */
    public class ExampleToolGroup : ToolGroup
    {
        public override string IconName => "PriorityToolGroupIcon";

        public override string DisplayNameLocKey => "ExampleMod.ToolGroups.ExampleToolGroup";
    }
}
