using System;
using Timberborn.PrioritySystem;
using UnityEngine;

namespace TimberApi.ToolSystem.Tools.BuilderPriority
{
    public class BuilderPriorityToolToolInformation
    {
        public BuilderPriorityToolToolInformation(string priority)
        {
            if(Enum.TryParse(priority, out Priority result))
            {
                Priority = result;
            }
            else
            {
                TimberApi.ConsoleWriter.Log($"Priority {priority} is not not a valid priority. Defaulting back to Normal", LogType.Warning);
                Priority = Priority.Normal;
            }
        }

        public Priority Priority { get; }
    }
}