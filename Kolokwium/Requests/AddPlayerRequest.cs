using System;
namespace Kolokwium.Requests
{
    public class AddPlayerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Brithdate { get; set; }
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }
    }
}
