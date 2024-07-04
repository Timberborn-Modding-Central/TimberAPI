using System.Collections.Generic;
using System.Linq;
using Timberborn.BlockSystem;
using Timberborn.PrefabSystem;
using Timberborn.PreviewSystem;

namespace BluePrint;

public class BlueprintPreviewPlacerFactory
{
    private readonly PreviewFactory _previewFactory;

    private readonly PrefabNameMapper _prefabNameMapper;

    private readonly PreviewShower _previewShower;

    private readonly BlockValidator _blockValidator;

    private readonly BlockService _blockService;

    private readonly PreviewValidationService _previewValidationService;

    public BlueprintPreviewPlacerFactory(PreviewFactory previewFactory, PrefabNameMapper prefabNameMapper,
        PreviewShower previewShower, BlockValidator blockValidator, BlockService blockService,
        PreviewValidationService previewValidationService)
    {
        _previewFactory = previewFactory;
        _prefabNameMapper = prefabNameMapper;
        _previewShower = previewShower;
        _blockValidator = blockValidator;
        _blockService = blockService;
        _previewValidationService = previewValidationService;
    }

    public BlueprintPreviewPlacer Create(Blueprint blueprint)
    {
        var previews = CreatePreviews(blueprint.BlueprintItems);

        return new BlueprintPreviewPlacer(
            _previewShower,
            _blockValidator,
            _blockService,
            _previewValidationService,
            false,
            previews,
            blueprint.BlueprintItems.Select(item => item.Placement).ToArray(),
            blueprint
        );
    }

    private Preview[] CreatePreviews(IReadOnlyList<BlueprintItem> blueprintItems)
    {
        var previews = new Preview[blueprintItems.Count];

        for (var index = 0; index < blueprintItems.Count; index++)
        {
            var prefab = _prefabNameMapper.GetPrefab(blueprintItems[index].TemplateName);
            var preview = _previewFactory.Create(prefab.GetComponentFast<PlaceableBlockObject>());
            preview.GetComponentFast<BlockObject>().MarkAsPreview();
            previews[index] = preview;
        }

        return previews;
    }
}