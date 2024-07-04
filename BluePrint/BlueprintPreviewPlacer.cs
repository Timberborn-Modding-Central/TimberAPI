using System.Collections.Generic;
using System.Linq;
using Timberborn.BlockSystem;
using Timberborn.Coordinates;
using Timberborn.PreviewSystem;
using UnityEngine;

namespace BluePrint;

public class BlueprintPreviewPlacer : PreviewPlacer
{
    public Blueprint Blueprint { get; }

    private readonly Placement[] _previewPlacements;
    
    public BlueprintPreviewPlacer(PreviewShower previewShower, BlockValidator blockValidator, BlockService blockService,
        PreviewValidationService previewValidationService, bool treatPreviewsAsSingle, Preview[] previews,
        Placement[] previewPlacements, Blueprint blueprint)
        : base(previewShower, blockValidator, blockService, previewValidationService, treatPreviewsAsSingle, previews)
    {
        _previewPlacements = previewPlacements;
        Blueprint = blueprint;
    }

    public void Show(Vector3Int anchorCoordinate, Orientation orientation = Orientation.Cw0)
    {
        var placements = _previewPlacements
            .Select(previewPlacement => new Placement(anchorCoordinate + previewPlacement.Coordinates, previewPlacement.Orientation, previewPlacement.FlipMode));

        ShowPreviews(placements);
    }
    
    public IEnumerable<Placement> GetBuildableCoordinates(Vector3Int anchorCoordinate, Orientation orientation = Orientation.Cw0)
    {
        var placements = _previewPlacements
            .Select(previewPlacement => new Placement(anchorCoordinate + previewPlacement.Coordinates, previewPlacement.Orientation, previewPlacement.FlipMode));

        return GetBuildableCoordinates(placements);
    }
}