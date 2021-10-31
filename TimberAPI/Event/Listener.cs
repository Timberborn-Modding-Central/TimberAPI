using Bindito.Core;
using Timberborn.SingletonSystem;

namespace TimberbornAPI.Event {
    /**
     * Extend Listener class to automatically register event listening
     * Listen to any event with [OnEvent]
     * 
     * You must also bind that class in a Configurator and add it with 
     * TimberAPI.Depeendencies.AddConfigurator()
     */
    public abstract class Listener : ILoadableSingleton {
        private EventBus _eventBus;

        [Inject]
        public void InjectDependencies(EventBus eventBus) {
            _eventBus = eventBus;
        }

        public void Load() {
            _eventBus.Register(this);
        }
    }
}
