using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Models
{
    public partial class PlayerScoreDetail
    {
        public int? PlayerId { get; set; }
        public int? Score { get; set; }
        public string Nickname { get; set; }
    }
}
