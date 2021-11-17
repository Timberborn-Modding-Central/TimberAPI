using Bindito.Core;
using Timberborn.SingletonSystem;

namespace TimberbornAPI.EventSystem
{
    /// <summary>
    /// Extend Event Listener class to automatically register event listening
    /// Listen to any event with [OnEvent]
    /// </summary>
    /// <remarks>
    /// You must also bind that class in a Configurator and add it with
    /// TimberAPI.Dependency.AddConfigurator()
    /// </remarks>
    public abstract class EventListener : ILoadableSingleton
    {
        private EventBus _eventBus;

        [Inject]
        public void InjectDependencies(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Load()
        {
            _eventBus.Register(this);
        }
    }
}
