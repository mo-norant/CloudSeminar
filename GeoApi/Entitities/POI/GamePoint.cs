using GeoGame.Entitities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Entitities.POI
{
    public class GamePoint : Location
    {
        public bool IsActive { get; set; }
        public int ScorePoints { get; set; }
    }
}
