using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Controllers
{
    public class PlayerController : Controller
    {

        private readonly youshallpassContext database;

        public static int EMPTY_NICKNAME = 100;
        public static int EMPTY_EMAIL = 101;
        public static int EMPTY_AGE = 102;
        public static int EMPTY_COUNTRY = 103;

        public PlayerController(youshallpassContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var players = database.Players.ToList();

            return View(players);
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
                return BadRequest(new
                {
                    error = "Empty Name",
                    code = EMPTY_NICKNAME
                });
            }

            if (player.Email == null || player.Email.Trim().Length == 0)
            {
                return BadRequest(new
                {
                    error = "Empty email",
                    code = EMPTY_EMAIL
                });
            }

            if (player.Age == 0)
            {
                return BadRequest(new
                {
                    error = "Empty ",
                    code = EMPTY_AGE
                });
            }

            if (player.Country == null || player.Country.Trim().Length == 0)
            {
                return BadRequest(new
                {
                    error = "Empty Country",
                    code = EMPTY_COUNTRY
                });
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

            var id = player.Id;

            database.SaveChanges();

            return RedirectToAction("Game", "Home");
        }
    }
}
