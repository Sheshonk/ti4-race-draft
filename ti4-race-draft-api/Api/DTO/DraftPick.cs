namespace ti4_race_draft_api.DTO
{
    public class DraftPick
    {
        public int DraftId { get; set; }
        public int GameId { get; set; }
        public int GroupId { get; set; }
        public int PlayerId { get; set; }
        public Guid AuthToken { get; set; }
    }
}
