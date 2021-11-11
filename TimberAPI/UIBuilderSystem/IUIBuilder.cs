namespace TimberbornAPI.UIBuilderSystem
{
    public interface IUIBuilder
    {
        /// <summary>
        /// Creates a box builder for making boxes
        /// </summary>
        IUIBoxBuilder CreateBoxBuilder();
        
        /// <summary>
        /// Creates a Component builder for making components/fragments
        /// </summary>
        IUIComponentBuilder CreateComponentBuilder();
    }
}