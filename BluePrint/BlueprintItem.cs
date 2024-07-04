using Timberborn.Coordinates;
using UnityEngine;

namespace BluePrint;

public class BlueprintItem
{
    public BlueprintItem(string templateName, Vector3Int coordinates, Orientation orientation, FlipMode flipMode)
    {
        TemplateName = templateName;
        Placement = new Placement(coordinates, orientation, flipMode);
    }

    public string TemplateName { get; }
    
    public Placement Placement { get; }
}