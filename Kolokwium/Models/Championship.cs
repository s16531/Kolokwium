using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models
{
    public class Championship
    {
        [Key]
        public int IdChampionship { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }
        public ICollection<ChampionshipTeam> ChampionshipTeams { get; set; }
    }
}
