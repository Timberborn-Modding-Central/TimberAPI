using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.EntityLinkerSystem
{
    //public abstract class BaseEntityLink<TLinker, TLinkee> : IEntityLink<TLinker, TLinkee>
    //    where TLinker : IEntityLinker
    //    where TLinkee : IEntityLinkee
    public abstract class BaseEntityLink<TLinker, TLinkee> : IEntityLink<TLinker, TLinkee>
    {
        public TLinker Linker { get; protected set; }

        public TLinkee Linkee { get; protected set; }

        public BaseEntityLink(TLinker linker,
                              TLinkee linkee)
        {
            Linker = linker;
            Linkee = linkee;
        }
    }
}
