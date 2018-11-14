using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Entitities.Models
{
    public class GamePlayer 
    {
        [Key]
        public string GamePlayerID { get; set; }
        public int Score { get; private set; }

        public void appendScore(int score)
        {
            Score += score;
        }

    }
}
