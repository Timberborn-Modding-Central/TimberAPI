using System;
using System.Collections.Generic;
using Timberborn.Persistence;
using UnityEngine;

namespace TimberbornAPI.EntityLinkerSystem
{
    public abstract class BaseEntityLinker<TLink, TLinkee, TLinker> : MonoBehaviour, IEntityLinker<TLink, TLinkee>
        where TLinkee : IEntityLinkee<TLink>
        where TLinker : IEntityLinker<TLink, TLinkee>
        where TLink : IEntityLink<TLinker, TLinkee>
    {
        protected static readonly ComponentKey EntityLinkerKey = new ComponentKey("EntityLinker");
        protected static readonly ListKey<TLink> EntityLinksKey = new ListKey<TLink>(nameof(EntityLinks));

        internal readonly List<TLink> _entityLinks = new List<TLink>();
        public IReadOnlyCollection<TLink> EntityLinks { get; private set; }

        public int MaxLinks { get; private set; }


        public virtual void Awake()
        {
            MaxLinks = 1;
            EntityLinks = _entityLinks.AsReadOnly();
        }

        public virtual void Save(IEntitySaver entitySaver)
        {
            IObjectSaver component = entitySaver.GetComponent(EntityLinkerKey);
            component.Set(EntityLinksKey, EntityLinks);
        }

        public virtual void Load(IEntityLoader entityLoader)
        {
            if (!entityLoader.HasComponent(EntityLinkerKey))
            {
                return;
            }
            IObjectLoader component = entityLoader.GetComponent(EntityLinkerKey);
            if (component.Has(EntityLinksKey))
            {
                _entityLinks.AddRange(component.Get(EntityLinksKey));

                foreach (var link in EntityLinks)
                {
                    PostCreateLink(link);
                }
            }
        }

        public virtual void OnEnterFinishedState()
        {
            //Nothing to do here?
        }

        public virtual void OnExitFinishedState()
        {
            RemoveAllLinks();
        }

        public virtual void CreateLink(TLinkee linkee)
        {
            var link = (TLink)Activator.CreateInstance(typeof(TLink), this, linkee);
            AddLink(link);
            PostCreateLink(link);
        }

        public virtual void AddLink(TLink link)
        {
            _entityLinks.Add(link);
        }

        public virtual void PostCreateLink(TLink link)
        {
            link.Linkee.AddLink(link);
        }

        public virtual void RemoveLink(TLink link)
        {
            if (!_entityLinks.Remove(link))
            {
                throw new InvalidOperationException($"Couldn't remove {link} from {this}, it wasn't added.");
            }
            PostRemoveLink(link);
        }

        public virtual void PostRemoveLink(TLink link)
        {
            link.Linkee.RemoveLink(link);
        }

        public virtual void RemoveAllLinks()
        {
            foreach(var link in EntityLinks)
            {
                PostRemoveLink(link);
            }
            _entityLinks.Clear();
        }
    }
}
