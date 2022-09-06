namespace TimberAPIExample.Examples.EntityLinkerExample
{
    internal class EntityActions : IEntityAction
    {
        // We can give entities custom MonoBehaviors or other Components when they are constructed
        public void ApplyToEntity(GameObject entity)
        {
            //Add custom class to Stockpiles so we hook into the Links
            if (entity.GetComponent<Stockpile>() != null &&
                entity.GetComponent<EntityLinker>() != null)
            {
                entity.AddComponent<WarehouseLinkService>();
            }

        }
    }
}
