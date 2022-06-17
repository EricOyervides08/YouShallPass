using Microsoft.AspNetCore.Http;
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

            HttpContext.Session.SetInt32("PlayerId", playerId.id);

            //ViewData["id"] = playerId.id;

            return RedirectToAction("Game");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = database.Players.SingleOrDefault(x => x.Id == id);

            if(player == null)
            {
                TempData["Error"] = "No se encontro usuario";
                return RedirectToAction("Register");
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Player editPlayer)
        {
            if (!ModelState.IsValid)
            {
                TempData["ModelError"] = "Error en el modelo";
                return View(editPlayer);
            }

            var player = database.Players.SingleOrDefault(x => x.Id == editPlayer.Id);

            if (player == null)
            {
                //enviar error
                return RedirectToAction("Register");
            }

            if (editPlayer.Email == null || editPlayer.Email.Trim().Length == 0)
            {
                ViewData["Error"] = "Falta email";
                return View(player);
            }

            if (editPlayer.Age == 0)
            {
                ViewData["Error"] = "Falta edad";
                return View(player);
            }

            if (editPlayer.Country == null || editPlayer.Country.Trim().Length == 0)
            {
                ViewData["Error"] = "Falta pais";
                return View(player);
            }

            var sql = $"call sp_player_update('{editPlayer.Nickname}','{editPlayer.Email}','{editPlayer.Age}'::int2,'{editPlayer.Country}')";

            try
            {
                var result = database.Database.ExecuteSqlRaw(sql);
                //var result = database.Users.FromSqlRaw(sql);

            }
            catch (Exception e)
            {
                return ValidationProblem();
            }

            var idSql = $"select max(players.id) as PlayerId from players where players.nickname = '{editPlayer.Nickname}'";
            var idResult = database.Games.FromSqlRaw(idSql).ToList();
            var playerId = idResult[0];

            database.SaveChanges();

            return View("Game", playerId);
        }

        public IActionResult Delete(int id)
        {
            var player = database.Players.SingleOrDefault(x => x.Id == id);

            if (player == null)
            {
                //enviar error
                return RedirectToAction("Register");
            }

            database.Players.Remove(player);

            database.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Game()
        {
            try
            {
                var playerId = HttpContext.Session.GetInt32("PlayerId");

                ViewData["id"] = playerId;

                SimplePlayer player = new SimplePlayer();

                if (playerId != null)
                {
                    player.id = playerId.GetValueOrDefault();
                }

                return View(player);
            }
            catch (Exception e)
            {
                return View("Register");
            }
            
        }

        [HttpPost]
        public IActionResult Game(Game game)
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
