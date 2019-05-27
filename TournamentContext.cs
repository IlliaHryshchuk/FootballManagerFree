using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FootballManagerFree
{
    class TournamentContext : DbContext
    {
        public TournamentContext() : base("DbConnection")
        {
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<FootballTeam> Fteams { get; set; }
        public DbSet<Tournament> Tours { get; set; }
    }
}
