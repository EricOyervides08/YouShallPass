using Microsoft.EntityFrameworkCore;

namespace TestApp.Models
{
    [Keyless]
    public class Scoreboard
    {
        public int playerid { get; set; }
        public int highscore { get; set; }
        public string nickname { get; set; }
    }
}
