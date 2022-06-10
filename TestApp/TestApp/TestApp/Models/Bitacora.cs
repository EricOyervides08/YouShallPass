using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp.Models
{
    public partial class Bitacora
    {
        public int? Ids { get; set; }
        public char Operation { get; set; }
        public int? Userid { get; set; }
        public string Nickname { get; set; }
        public DateTime? TimeLog { get; set; }
    }
}
