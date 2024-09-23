using Timberborn.ConstructionMode;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.ConstructionMode;

public class ConstructionModeToolGroup(
    string id,
    string? groupId,
    int order,
    string section,
    string displayNameLocKey,
    bool devMode,
    Sprite icon) : ApiToolGroup(id, groupId, order, section, displayNameLocKey, devMode, icon), IConstructionModeEnabler;