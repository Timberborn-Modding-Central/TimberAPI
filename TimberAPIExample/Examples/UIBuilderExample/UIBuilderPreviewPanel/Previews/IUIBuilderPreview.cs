using UnityEngine.UIElements;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public interface IUIBuilderPreview
    {
        string GetPreviewName();
        
        VisualElement GetPreview();
    }
}