using System;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Models
{
    [Keyless]
    public class Score
    {
        public int score { get; set; }
    }

}
