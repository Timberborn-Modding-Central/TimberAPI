using Timberborn.Persistence;
using TimberbornAPI.Internal;

namespace TimberbornAPI.EntityLinkerSystem
{
    /// <summary>
    /// Defines how and instance of EntityLink should be serialized.
    /// Used when an EntityLinker which contains EntityLinks is saved/loaded
    /// </summary>
    public class EntityLinkSerializer : IObjectSerializer<EntityLink>
    {
        protected static readonly PropertyKey<EntityLinker> LinkerKey = new PropertyKey<EntityLinker>("Linker");
        protected static readonly PropertyKey<EntityLinker> LinkeeKey = new PropertyKey<EntityLinker>("Linkee");

        public virtual Obsoletable<EntityLink> Deserialize(IObjectLoader objectLoader)
        {
            try
            {
                var linker = objectLoader.Get(LinkerKey);
                var linkee = objectLoader.Get(LinkeeKey);
                var link = new EntityLink(linker, linkee);
                return link;
            }
            catch(ObsoleteValueException ex)
            {
                TimberAPIPlugin.Log.LogWarning($"{ex.Message}");
                TimberAPIPlugin.Log.LogWarning($"Skipping EntityLink.");
                return null;
            }
        }

        public virtual void Serialize(EntityLink value, IObjectSaver objectSaver)
        {
            objectSaver.Set(LinkerKey, value.Linker);
            objectSaver.Set(LinkeeKey, value.Linkee);
        }
    }
}
