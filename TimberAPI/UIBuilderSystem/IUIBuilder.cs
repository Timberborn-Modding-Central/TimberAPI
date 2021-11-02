namespace TimberbornAPI.UIBuilderSystem
{
    public interface IUIBuilderFactory
    {
        IUIBoxBuilder CreateBoxBuilder();
        IUIComponentBuilder CreateComponentBuilder();
    }
}