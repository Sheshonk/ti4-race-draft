﻿namespace ti4_race_draft_api.DTO
{
    public class DraftPick
    {
        public int RaceId { get; set; }
        public int GroupId { get; set; }
        public Guid AuthToken { get; set; }
    }
}