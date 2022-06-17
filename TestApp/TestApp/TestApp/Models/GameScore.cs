using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Models
{
    [Keyless]
    public class GameScore
    {
        public int score { get; set; }
        public int id { get; set; }
    }
}