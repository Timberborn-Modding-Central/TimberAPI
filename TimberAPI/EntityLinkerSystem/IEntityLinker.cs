using System.Collections.Generic;
using Timberborn.ConstructibleSystem;
using Timberborn.Persistence;

namespace TimberbornAPI.EntityLinkerSystem
{
    public interface IEntityLinker<TLink, TLinkee> : IPersistentEntity, IFinishedStateListener
    {
        public IReadOnlyCollection<TLink> EntityLinks { get; }

        public int MaxLinks { get; }

        public void CreateLink(TLinkee linkee);

        public void PostCreateLink(TLink link);

        public void RemoveLink(TLink link);

        public void PostRemoveLink(TLink link);

        void RemoveAllLinks();
    }
}
