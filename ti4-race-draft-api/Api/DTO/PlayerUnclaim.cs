namespace ti4_race_draft_api.DTO
{
    public class PlayerUnclaim
    {
        public Guid AdminAuthToken { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
    }
}
