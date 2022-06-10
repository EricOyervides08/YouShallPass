using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Models
{
    public partial class Game
    {
        public int GameId { get; set; }
        public int? Score { get; set; }
        public DateTime? GameDate { get; set; }
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}
