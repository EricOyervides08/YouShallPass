using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly youshallpassContext database;

        public static int EMPTY_NICKNAME = 100;
        public static int EMPTY_EMAIL = 101;
        public static int EMPTY_AGE = 102;
        public static int EMPTY_COUNTRY = 103;

        public HomeController(youshallpassContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Player player)
        {

            if (player == null || player.Nickname == null || player.Nickname.Trim().Length == 0)
            {
                ViewData["Error"] = "Falta nickname";
                return View(player);
            }

            if (player.Email == null || player.Email.Trim().Length == 0)
            {
                ViewData["Error"] = "Falta email";
                return View(player);
            }

            if (player.Age == 0)
            {
                ViewData["Error"] = "Falta edad";
                return View(player);
            }

            if (player.Country == null || player.Country.Trim().Length == 0)
            {
                ViewData["Error"] = "Falta pais";
                return View(player);
            }

            var sql = $"call sp_player_insert('{player.Nickname}','{player.Email}','{player.Age}'::int2,'{player.Country}')";

            try
            {
                var result = database.Database.ExecuteSqlRaw(sql);
                //var result = database.Users.FromSqlRaw(sql);

            }
            catch (Exception e)
            {
                return ValidationProblem();
            }

            var idSql = $"select max(players.id) as id from players where players.nickname = '{player.Nickname}'";
            var idResult = database.SimplePlayer.FromSqlRaw(idSql).ToList();
            var playerId = idResult[0];

            //TempData["playerId"] = id;

            database.SaveChanges();

            return View("Game", playerId);
        }

        [HttpGet]
        public IActionResult Game()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Game(Player player)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Scoreboard()
        {
            var sql = $"select playerid, nickname, highscore from fn_topten_scores()";

            var result = database.Scoreboard.FromSqlRaw(sql).ToList();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
