using GeoGame.Entitities;
using GeoGame.Entitities.Models;
using GeoGame.Entitities.POI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Services
{
    public class AreaService : IAreaService
    {
        private readonly GameContext context;

        public AreaService(GameContext context)
        {
            this.context = context;
        }

        public async Task PointReached(GamePlayer player, GamePoint poi)
        {
            player.appendScore(poi.ScorePoints);
            poi.IsActive = false;
            await context.SaveChangesAsync();
        }

        public async Task CreateUser(IdentityUser user)
        {
            var player = new GamePlayer
            {
                GamePlayerID = user.Id
            };
            await context.Players.AddAsync(player);
            await context.SaveChangesAsync();
        }

        public async Task<Game> CreateGame(Location startlocation, List<string> playerIDs,  int countPointofInterests)
        {

            var game = new Game
            {
                Area = new Area
                {
                    Name = startlocation.Name
                }
            };
            game.Area.GenerateLocations(startlocation, countPointofInterests);
            game.Players = await GetAllPlayers(playerIDs);
            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
            return game;
        }

        private async Task<ICollection<GamePlayer>> GetAllPlayers(List<string> playerIDs)
        {
            ICollection<GamePlayer> l = new List<GamePlayer>();
            foreach (string id in playerIDs)
            {
                var p = await context.Players.FirstOrDefaultAsync(i => i.GamePlayerID == id);
                l.Add(p);
            }
            return l;
        }

        public async Task<Game> GetGame(int GameID)
        {
            var game = await context.Games
                .Include(i => i.Area)
                    .ThenInclude(i => i.PointofInterests)
                .Include(i => i.Players)
                .FirstOrDefaultAsync(i => i.GameID == GameID);
            return game;
        }
    }
}
