using System.Collections.Generic;
using Timberborn.ConstructibleSystem;
using Timberborn.EntitySystem;

namespace TimberbornAPI.EntityLinkerSystem
{
    public interface IEntityLinkee<TLink> : IRegisteredComponent, IFinishedStateListener
    {
        public IReadOnlyCollection<TLink> EntityLinks { get; }

        public void AddLink(TLink link);

        public void RemoveLink(TLink link);

        public void RemoveAllLinks();
    }
}
