using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private readonly youshallpassContext database;

        public GameApiController(youshallpassContext database)
        {
            this.database = database;
        }

        // GET: api/game
        //[HttpGet]
        //public IEnumerable<Player> Get()
        //{
        //    return database.Players.ToList();
        //}

        // GET api/game
        //[HttpGet("{score}")]
        //public IActionResult Get(string score)
        //{

        //    if (score == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(score);
        //}

        //POST api/game
        [HttpPost]
        public IActionResult Post([FromBody] GameScore gameScore)
        {
            var playerId = HttpContext.Session.GetInt32("playerId");

            var sql = $"call sp_games_insert({gameScore.score}::int4, '{playerId}')";

            try
            {
                var result = database.Database.ExecuteSqlRaw(sql);
                return Ok(result);
            }
            catch(Exception e)
            {
                return ValidationProblem();
            }

        }

        // get api/game
        [HttpGet]
        public IActionResult Get() //Score table
        {
            //query
            var sql = $"select playerid, nickname, score from fn_player_hiscore()";

            var result = database.PlayerScore.FromSqlRaw(sql).ToList();

            return Ok(result);
        }

        // get api/game/id
        [HttpGet("{id}")]
        public IActionResult Get(int id) //score and highscore
        {
            //query
            var sql = $"select score from games where games.player_id = {id} order by games.game_id desc limit 1";

            var result = database.GameScore.FromSqlRaw(sql).ToList();

            int playerScore;

            Int32.TryParse(result[0].score, out playerScore);

            return Ok(playerScore);
        }
        

        //// PUT api/person/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] User editedUser)
        //{

        //    if (editedUser.Id != id)
        //    {
        //        return BadRequest(new
        //        {
        //            error = "Id no coincide",
        //            code = 400
        //        });
        //    }

        //    var user = database.Users.SingleOrDefault(x => x.Id == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    if (user == null || user.Name == null || user.Name.Trim().Length == 0)
        //    {
        //        return BadRequest(new
        //        {
        //            error = "Empty Name",
        //            code = EMPTY_NAME
        //        });
        //    }

        //    if (user.Country == null || user.Country == null || user.Country.Trim().Length == 0)
        //    {
        //        return BadRequest(new
        //        {
        //            error = "Empty Password",
        //            code = EMPTY_COUNTRY
        //        });
        //    }

        //    user.Address = editedUser.Address;
        //    user.Age = editedUser.Age;
        //    user.Name = editedUser.Name;
        //    user.Country = editedUser.Country;

        //    database.SaveChanges();

        //    return Ok();
        //}

        //// DELETE api/<PersonApiController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var user = database.Users.SingleOrDefault(x => x.Id == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    database.Users.Remove(user);
        //    database.SaveChanges();

        //    return Ok();
        //}
    }
}
