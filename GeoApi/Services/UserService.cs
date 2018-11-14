using Auth;
using GeoGame.Entitities;
using GeoGame.Entitities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Services
{
    public class UserService : IUserService
    {
        private readonly GameContext context;
        public UserService(GameContext context)
        {
            this.context = context;
        }

        public async Task createUser(Player player)
        {
            var gameplayer = new GamePlayer
            {
                GamePlayerID = player.Id
            };

            await context.Players.AddAsync(gameplayer);
            await context.SaveChangesAsync();
        }


    }
}
