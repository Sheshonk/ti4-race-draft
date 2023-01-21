namespace ti4_race_draft_api.DTO
{
    public class GroupDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Winner { get; set; }
        public List<RaceDetail> Races { get; set; }
    }
}
