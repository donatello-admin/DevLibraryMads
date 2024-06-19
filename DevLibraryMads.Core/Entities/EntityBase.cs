namespace DevLibraryMads.Core.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
