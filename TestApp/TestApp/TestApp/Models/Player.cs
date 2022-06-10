using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Models
{
    public partial class Player
    {
        public Player()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
