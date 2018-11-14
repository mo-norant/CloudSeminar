using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Entitities.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public Area Area { get; set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<GamePlayer> Players { get; set; }

        public Game()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
