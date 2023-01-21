using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Entities
{
    public class Draft : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int GameId { get; set; }
        public int? GroupId { get; set; }
        public int? PlayerId { get; set; }
        public int? RaceId { get; set; }
        public int Order { get; set; }


        public Game Game { get; set; }
        public Group? Group { get; set; }
        public Player? Player { get; set; }
        public Race Race { get; set; }
    }
}
