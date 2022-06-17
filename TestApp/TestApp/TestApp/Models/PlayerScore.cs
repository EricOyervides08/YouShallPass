using Microsoft.EntityFrameworkCore;

namespace TestApp.Models
{
    [Keyless]
    public class PlayerScore
    {
        public int player_id { get; set; }
        public string nickname { get; set; }
        public int score { get; set; }
    }
}