namespace TimberbornAPI.EntityLinkerSystem
{
    /// <summary>
    /// Represent a link between two entities. A Link is used when two entities should
    /// be connected to eachother somehow. For example to guide the behaviour of the other 
    /// based on the stats of the other. 
    /// </summary>
    public class EntityLink
    {
        public EntityLinker Linker { get; private set; }

        public EntityLinker Linkee { get; private set; }

        public EntityLink(
            EntityLinker linker,
            EntityLinker linkee)
        {
            Linker = linker;
            Linkee = linkee;
        }
    }
}
