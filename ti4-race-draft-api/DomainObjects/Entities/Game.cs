namespace DomainObjects.Entities
{
    public class Game : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid PublicId { get; set; }
    }
}
