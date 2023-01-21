namespace DomainObjects.Entities
{
    public class Game : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid PublicId { get; set; }
        public int? CurrentPlayerId { get; set; }
        public bool Complete { get; set; }
    }
}
