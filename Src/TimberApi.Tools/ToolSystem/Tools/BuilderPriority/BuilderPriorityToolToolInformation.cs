using System;
using Timberborn.PrioritySystem;
using UnityEngine;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

public class BuilderPriorityToolToolInformation
{
    public BuilderPriorityToolToolInformation(string priority)
    {
        if (Enum.TryParse(priority, out Priority result))
        {
            Priority = result;
        }
        else
        {
            Debug.LogWarning($"Priority {priority} is not not a valid priority. Defaulting back to Normal");
            Priority = Priority.Normal;
        }
    }

    public Priority Priority { get; }
}