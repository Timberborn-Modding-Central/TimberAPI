using UnityEngine.UIElements;

namespace TimberbornAPI.EntityLinkerSystem.UI
{
    public interface IBaseEntityLinkViewFactory
    {
        VisualElement CreateForLinkee(string buttonLabelText);
        VisualElement CreateForLinker(string buttonLabelText);
    }
}