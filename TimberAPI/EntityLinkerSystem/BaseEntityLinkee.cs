using Bindito.Core;
using System.Collections.Generic;
using Timberborn.EntitySystem;
using Timberborn.TickSystem;

namespace TimberbornAPI.EntityLinkerSystem
{
    public abstract class BaseEntityLinkee<TLink, TLinker, TLinkee> : TickableComponent, IEntityLinkee<TLink>
        where TLinkee : IEntityLinkee<TLink>
        where TLink : IEntityLink<TLinker, TLinkee>
        where TLinker : IEntityLinker<TLink, TLinkee>
    {
        private readonly List<TLink> _entityLinks = new List<TLink>();
        public IReadOnlyCollection<TLink> EntityLinks { get; private set; }

        private EntityComponentRegistry _entityComponentRegistry;

        [Inject]
        public void InjectDependencies(
            EntityComponentRegistry entityComponentRegistry)
        {
            _entityComponentRegistry = entityComponentRegistry;
        }

        public virtual void Awake()
        {
            EntityLinks = _entityLinks.AsReadOnly();
            base.enabled = false;
        }

        public virtual void OnEnterFinishedState()
        {
            enabled = true;
            _entityComponentRegistry.Register(this);
        }

        public virtual void OnExitFinishedState()
        {
            enabled = false;
            _entityComponentRegistry.Unregister(this);
            RemoveAllLinks();
        }

        public virtual void AddLink(TLink link)
        {
            _entityLinks.Add(link);
        }

        public virtual void RemoveLink(TLink link)
        {
            _entityLinks.Remove(link);
        }

        public void RemoveAllLinks()
        {
            for (int i = _entityLinks.Count - 1; i >= 0; i--)
            {
                var link = _entityLinks[i];
                link.Linker.RemoveLink(link);
            }
        }

        public override abstract void Tick();
    }
}
