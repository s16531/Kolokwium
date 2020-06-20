using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models
{
    public class ChampionshipTeam
    {
        [Key]
        public int IdChampionship { get; set; }
        public int IdTeam { get; set; }
        public Team Team { get; set; }
        public Championship Championship { get; set; }
        public float Score { get; set; }
    }
}
