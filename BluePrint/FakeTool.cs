using Timberborn.CursorToolSystem;
using Timberborn.InputSystem;
using Timberborn.SingletonSystem;

namespace BluePrint;

public class FakeTool : IInputProcessor, ILoadableSingleton
{
    private BlueprintPreviewPlacer? _blueprintPreviewPlacer;
    
    private readonly InputService _inputService;

    private readonly BlueprintService _blueprintService;
    
    private readonly CursorCoordinatesPicker _cursorCoordinatesPicker;

    public FakeTool(InputService inputService, BlueprintService blueprintService, CursorCoordinatesPicker cursorCoordinatesPicker)
    {
        _inputService = inputService;
        _blueprintService = blueprintService;
        _cursorCoordinatesPicker = cursorCoordinatesPicker;
    }

    public bool ProcessInput()
    {
         var cursorCoordinates = _cursorCoordinatesPicker.CursorCoordinates();
         
         if (cursorCoordinates == null)
         {
             return false;
         }

         if (_blueprintPreviewPlacer != null)
         {
             _blueprintPreviewPlacer.Show(cursorCoordinates.Value.TileCoordinates);
         }
         
         if (!_inputService.IsKeyDown("BluePrint")) 
         {
             return false;
         }

         if (_blueprintPreviewPlacer == null)
         {
             _blueprintPreviewPlacer = _blueprintService.LoadBlueprint();
         }
         else
         {
             _blueprintService.PlaceBlueprint(_blueprintPreviewPlacer, cursorCoordinates.Value.TileCoordinates);
             _blueprintPreviewPlacer.HideAllPreviews();
             _blueprintPreviewPlacer = null;
         }

         return false;
    }

    public void Load()
    {
        _inputService.AddInputProcessor(this);
    }
}