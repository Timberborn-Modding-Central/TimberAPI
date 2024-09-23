using Timberborn.PlantingUI;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.PlantingMode;

public class PlantingModeToolGroup(
    string id,
    string? groupId,
    int order,
    string section,
    string displayNameLocKey,
    bool devMode,
    Sprite icon)
    : ApiToolGroup(id, groupId, order, section, displayNameLocKey, devMode, icon), IPlantingToolGroup;