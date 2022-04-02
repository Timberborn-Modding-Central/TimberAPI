using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.ConstructibleSystem;
using Timberborn.EntitySystem;
using UnityEngine;

namespace TimberbornAPI.EntityLinkerSystem
{
    public interface IEntityLinkee<TLink> : IRegisteredComponent, IFinishedStateListener
    {
        public IReadOnlyCollection<TLink> EntityLinks { get; }

        public void AddLink(TLink link);

        public void RemoveLink(TLink link);

        //void RemoveAllLinks();
    }
}
