using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models
{
    public class PlayerTeam
    {
        [Key]
        public int IdPlayer { get; set; }
        public int IdTeam { get; set; }
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}
