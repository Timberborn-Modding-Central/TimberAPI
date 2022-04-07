namespace TimberbornAPI.EntityLinkerSystem
{
    /// <summary>
    /// Represent a link between two entities
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
