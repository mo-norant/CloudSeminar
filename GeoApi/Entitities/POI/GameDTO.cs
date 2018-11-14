using GeoGame.Entitities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoApi.Entitities.POI
{
    public class GameDTO
    {
        public Location StartLocation { get; set; }
        public List<string> playersIDs { get; set; }


    }
}
