using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.Persistence;

namespace TimberbornAPI.EntityLinkerSystem
{
    public abstract class BaseEntityLinkSerializer<TLink, TLinker, TLinkee> : IObjectSerializer<TLink>
        where TLink : IEntityLink<TLinker, TLinkee>
    {
        protected static readonly PropertyKey<TLinker> LinkerKey = new PropertyKey<TLinker>("EntityLinker");
        protected static readonly PropertyKey<TLinkee> LinkeeKey = new PropertyKey<TLinkee>("EntityLinkee");

        public virtual Obsoletable<TLink> Deserialize(IObjectLoader objectLoader)
        {
            var linker = objectLoader.Get(LinkerKey);
            var linkee = objectLoader.Get(LinkeeKey);

            var link = (TLink)Activator.CreateInstance(typeof(TLink), linker, linkee);

            return link;
        }

        public virtual void Serialize(TLink value, IObjectSaver objectSaver)
        {
            objectSaver.Set(LinkerKey, value.Linker);
            objectSaver.Set(LinkeeKey, value.Linkee);
        }

    }
}
