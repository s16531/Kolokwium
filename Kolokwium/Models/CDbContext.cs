using System;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{


    public class CDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }

        public CDbContext() { }

        public CDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
