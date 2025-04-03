using Timberborn.Persistence;

namespace TimberApi.EntityLinkerSystem;

/// <summary>
///     Defines how and instance of EntityLink should be serialized.
///     Used when an EntityLinker which contains EntityLinks is saved/loaded
/// </summary>
public class EntityLinkObjectSerializer : IValueSerializer<EntityLink>
{
    protected static readonly PropertyKey<EntityLinker> LinkerKey = new("Linker");
    
    protected static readonly PropertyKey<EntityLinker> LinkeeKey = new("Linkee");
    public void Serialize(EntityLink value, IValueSaver valueSaver)
    {
        IObjectSaver objectSaver = valueSaver.AsObject();
        
        if (value?.Linker != null)
        {
            objectSaver.Set(LinkerKey, value.Linker);
        }
        if (value?.Linkee != null)
        {
            objectSaver.Set(LinkeeKey, value.Linkee);
        }
    }

    public Obsoletable<EntityLink> Deserialize(IValueLoader valueLoader)
    {
        EntityLinker? linker = valueLoader.Has(LinkerKey) && valueLoader.GetObsoletable(LinkerKey, out EntityLinker value)
            ? valueLoader.Get(LinkerKey)
            : new EntityLinker();
        EntityLinker? linkee = valueLoader.Has(LinkeeKey) && valueLoader.GetObsoletable(LinkeeKey, out EntityLinker value2)
            ? valueLoader.Get(LinkeeKey)
            : new EntityLinker();
        var link = new EntityLink(linker, linkee);
        return link;
    }
}