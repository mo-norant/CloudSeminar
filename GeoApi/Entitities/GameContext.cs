using GeoGame.Entitities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Entitities
{
    public class GameContext : DbContext
    {

        public DbSet<Area> Areas { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GamePlayer> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        public GameContext(DbContextOptions<GameContext> options)
         : base(options)
        { }
    }
}
