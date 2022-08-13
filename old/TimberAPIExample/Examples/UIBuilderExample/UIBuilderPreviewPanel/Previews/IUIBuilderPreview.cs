using UnityEngine.UIElements;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public interface IUIBuilderPreview
    {
        string GetPreviewKey();
        
        string GetPreviewName();
        
        VisualElement GetPreview();
    }
}