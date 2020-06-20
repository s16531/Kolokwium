using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models
{
    public class Player
    {
        [Key]
        public int IdPlayer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
