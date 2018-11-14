using GeoGame.Entitities.Models;
using GeoGame.Entitities.POI;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Services
{
    public interface IAreaService
    {
        Task<Game> CreateGame(Location startlocation, List<string> playerIDs, int countPointofInterests);
        Task PointReached(GamePlayer player, GamePoint point);
        Task CreateUser(IdentityUser user);
        Task<Game> GetGame(int GameID);
    }
}
