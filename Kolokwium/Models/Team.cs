using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models
{
    public class Team
    {
        [Key]
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }
        public ICollection<PlayerTeam> PlayerTeams { get; set; }
        //public ICollection<ChampionshipTeam> ChampionshipTeams { get; set; }


    }
}
