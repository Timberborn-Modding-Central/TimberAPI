namespace TimberbornAPI.GameObjectModifier
{
    public interface IGameObjectModifierRegistry
    {
        /// <summary>
        /// Adds a modifier to the list, triggers when new objects are created or loaded
        /// </summary>
        /// <param name="gameObjectInitializer"></param>
        void AddModifier(IGameObjectModifier gameObjectInitializer);
    }
}