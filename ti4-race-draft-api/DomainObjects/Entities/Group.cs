using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Entities
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string Name { get; set; }
        public int GameId { get; set; }
        public bool Winner { get; set; }

        public Game Game { get; set; }
    }
}
