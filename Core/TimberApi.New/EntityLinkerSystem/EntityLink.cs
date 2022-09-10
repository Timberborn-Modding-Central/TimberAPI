namespace TimberApi.New.EntityLinkerSystem
{
    /// <summary>
    ///     Represent a link between two entities. A Link is used when two entities should
    ///     be connected to eachother somehow. For example to guide the behaviour of the other
    ///     based on the stats of the other. You could eg make floodagates be set to certain
    ///     height based on the water depth of the Stream Gauge it is linked to
    /// </summary>
    public class EntityLink
    {
        public EntityLink(EntityLinker linker, EntityLinker linkee)
        {
            Linker = linker;
            Linkee = linkee;
        }

        public EntityLinker Linker { get; }

        public EntityLinker Linkee { get; }
    }
}