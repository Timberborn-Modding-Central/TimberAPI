using Bindito.Core;
using Timberborn.SingletonSystem;

namespace TimberbornAPI.Event {
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
