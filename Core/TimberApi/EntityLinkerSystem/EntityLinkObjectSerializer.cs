using Timberborn.Persistence;

namespace TimberApi.EntityLinkerSystem
{
    /// <summary>
    ///     Defines how and instance of EntityLink should be serialized.
    ///     Used when an EntityLinker which contains EntityLinks is saved/loaded
    /// </summary>
    public class EntityLinkObjectSerializer : IObjectSerializer<EntityLink>
    {
        protected static readonly PropertyKey<EntityLinker> LinkerKey = new("Linker");
        protected static readonly PropertyKey<EntityLinker> LinkeeKey = new("Linkee");

        public virtual Obsoletable<EntityLink> Deserialize(IObjectLoader objectLoader)
        {
            EntityLinker? linker = objectLoader.Has(LinkerKey) && objectLoader.GetObsoletable(LinkerKey, out EntityLinker value)
                ? objectLoader.Get(LinkerKey)
                : new EntityLinker();
            EntityLinker? linkee = objectLoader.Has(LinkeeKey) && objectLoader.GetObsoletable(LinkeeKey, out EntityLinker value2)
                ? objectLoader.Get(LinkeeKey)
                : new EntityLinker();
            var link = new EntityLink(linker, linkee);
            return link;
        }

        public virtual void Serialize(EntityLink value, IObjectSaver objectSaver)
        {
            if (value?.Linker != null)
            {
                objectSaver.Set(LinkerKey, value.Linker);
            }
            if (value?.Linkee != null)
            {
                objectSaver.Set(LinkeeKey, value.Linkee);
            }
        }
    }
}