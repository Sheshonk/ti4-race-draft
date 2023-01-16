namespace DomainObjects.Entities
{
    public class Player : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int GameId { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public Guid? AuthToken { get; set; }
        public int DraftOrder { get; set; }


        public Game Game { get; set; }
    }
}
