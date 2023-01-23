namespace ti4_race_draft_api.DTO
{
    public class GameDetail
    {
        public GameDetail()
        {
            Players = new List<PlayerDetail>();
            Hand = new List<RaceDetail>();
            Groups = new List<GroupDetail>();
        }

        public int Id { get; set; }
        public int? AuthPlayerId { get; set; }
        public int? AdminId { get; set; }
        public PlayerDetail CurrentPlayer { get; set; }
        public RaceDetail SuperFaction { get; set; }
        public bool Complete { get; set; }
        public List<PlayerDetail> Players { get; set; }
        public List<RaceDetail> Hand { get; set; }
        public List<GroupDetail> Groups { get; set; }
    }
}
