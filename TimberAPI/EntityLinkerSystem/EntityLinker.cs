using Bindito.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.ConstructibleSystem;
using Timberborn.Persistence;
using UnityEngine;
using static TimberbornAPI.Internal.TimberAPIPlugin;

namespace TimberbornAPI.EntityLinkerSystem
{
    /// <summary>
    /// Defines the behaviour of Linkers. TimberAPI adds an instance of Entitylinker to
    /// all Building entities. EntityLinker is used to create new EntityLinks between two entities.
    /// If you want to create a new Link between EntityLinkers, use the CreateLink() method.
    /// If can be called in code or you could for example create an in game button
    /// which can make the call.
    /// </summary>
    public class EntityLinker : MonoBehaviour, IFinishedStateListener, IPersistentEntity
    {
        //Keys for saving/loading
        protected static readonly ComponentKey EntityLinkerKey = new ComponentKey("EntityLinker");
        protected static readonly ListKey<EntityLink> EntityLinksKey = new ListKey<EntityLink>(nameof(EntityLinks));

        internal readonly List<EntityLink> _entityLinks = new List<EntityLink>();
        public IReadOnlyCollection<EntityLink> EntityLinks { get; private set; }

        private EntityLinkSerializer _entityLinkSerializer;


        [Inject]
        public void InjectDependencies(EntityLinkSerializer entityLinkSerializer)
        {
            _entityLinkSerializer = entityLinkSerializer;
        }


        public virtual void Awake()
        {
            EntityLinks = _entityLinks.AsReadOnly();
        }

        /// <summary>
        /// Save existing Links
        /// </summary>
        /// <param name="entitySaver"></param>
        public virtual void Save(IEntitySaver entitySaver)
        {
            IObjectSaver component = entitySaver.GetComponent(EntityLinkerKey);
            component.Set(EntityLinksKey, EntityLinks, _entityLinkSerializer);
        }

        /// <summary>
        /// Load saves Links
        /// </summary>
        /// <param name="entityLoader"></param>
        public virtual void Load(IEntityLoader entityLoader)
        {
            if (!entityLoader.HasComponent(EntityLinkerKey))
            {
                return;
            }
            IObjectLoader component = entityLoader.GetComponent(EntityLinkerKey);
            if (component.Has(EntityLinksKey))
            {
                var links = component.Get(EntityLinksKey, _entityLinkSerializer);
                if (links == null)
                {
                    return;
                }
                var linkerLinks = links.Where(x => x != null && x.Linker == this).ToList(); 
                foreach (var link in linkerLinks)
                {
                    AddLinkInLinkee(link);
                }
                _entityLinks.AddRange(linkerLinks);
            }
        }

        public virtual void OnEnterFinishedState()
        {
            //Nothing to do here?
        }

        /// <summary>
        /// When entity is deleted, remove all links
        /// </summary>
        public virtual void OnExitFinishedState()
        {
            RemoveAllLinks();
        }

        /// <summary>
        /// Creates a new link where this in the Linker
        /// </summary>
        /// <param name="linkee"></param>
        public virtual void CreateLink(EntityLinker linkee)
        {
            if(linkee == this)
            {
                Log.LogWarning($"Tried to link entity with itself. Stopped linking.");
                return;
            }
            var link = new EntityLink(this, linkee);
            AddLink(link);
            AddLinkInLinkee(link);
        }

        /// <summary>
        /// Adds a new Link where this is the Linkee
        /// </summary>
        /// <param name="link"></param>
        public virtual void AddLink(EntityLink link)
        {
            _entityLinks.Add(link);
        }

        /// <summary>
        /// Add the Link on the Linkee
        /// </summary>
        /// <param name="link"></param>
        private void AddLinkInLinkee(EntityLink link)
        {
            link.Linkee.AddLink(link);
        }

        /// <summary>
        /// Deletes a Link and calls to remove the Link from the Linkee
        /// </summary>
        /// <param name="link"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual void DeleteLink(EntityLink link)
        {
            if (!_entityLinks.Remove(link))
            {
                throw new InvalidOperationException($"Couldn't remove {link} from {this}, it wasn't added.");
            }
            DeleteLinkFromLinkee(link);
        }


        /// <summary>
        /// Removes the Link from Linkee too
        /// </summary>
        /// <param name="link"></param>
        private void DeleteLinkFromLinkee(EntityLink link)
        {
            link.Linkee.RemoveLink(link);
        }

        /// <summary>
        /// Removes a Link from the list
        /// </summary>
        /// <param name="link"></param>
        public virtual void RemoveLink(EntityLink link)
        {
            _entityLinks.Remove(link);
        }

        /// <summary>
        /// Remvoes all existing Links
        /// </summary>
        public virtual void RemoveAllLinks()
        {
            foreach (var link in EntityLinks)
            {
                if(link.Linker == this)
                {
                    link.Linkee.RemoveLink(link);
                }
                else
                {
                    link.Linker.RemoveLink(link);
                }
            }
            _entityLinks.Clear();
        }
    }
}
