//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TestApp.Models;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace TestApp.Controllers
//{
//    [Route("api/person")]
//    [ApiController]
//    public class PersonApiController : ControllerBase
//    {
//        private readonly test_appContext database;

//        public static int EMPTY_NAME = 100;
//        public static int EMPTY_COUNTRY = 101;
//        public static int EMPTY_ADDRESS = 102;

//        public PersonApiController(test_appContext database)
//        {
//            this.database = database;
//        }
        
//        // GET: api/person
//        [HttpGet]
//        public IEnumerable<User> Get()
//        {
//            return database.Users.ToList();
//        }

//        // GET api/person/5
//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            var user = database.Users.SingleOrDefault(row => row.Id == id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            return Ok(user);
//        }

//        // POST api/<PersonApiController>
//        [HttpPost]
//        public IActionResult Post([FromBody] User user)
//        {
//            if(user == null ||  user.Name == null || user.Name.Trim().Length == 0 )
//            {
//                return BadRequest(new
//                {
//                    error = "Empty Name",
//                    code = EMPTY_NAME
//                }); 
//            }

//            if (user.Country == null || user.Country == null || user.Country.Trim().Length == 0)
//            {
//                return BadRequest(new
//                {
//                    error = "Empty Country",
//                    code = EMPTY_COUNTRY
//                });
//            }

//            var random = new System.Random();
//            user.Id = random.Next();

//            database.Users.Add(user);

//            database.SaveChanges();

//            return Ok();
//        }

//        // PUT api/person/5
//        [HttpPut("{id}")]
//        public IActionResult Put(int id, [FromBody] User editedUser)
//        {

//            if (editedUser.Id != id)
//            {
//                return BadRequest(new
//                {
//                    error = "Id no coincide",
//                    code = 400
//                });
//            }

//            var user = database.Users.SingleOrDefault(x => x.Id == id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            if (user == null || user.Name == null || user.Name.Trim().Length == 0)
//            {
//                return BadRequest(new
//                {
//                    error = "Empty Name",
//                    code = EMPTY_NAME
//                });
//            }

//            if (user.Country == null || user.Country == null || user.Country.Trim().Length == 0)
//            {
//                return BadRequest(new
//                {
//                    error = "Empty Password",
//                    code = EMPTY_COUNTRY
//                });
//            }

//            user.Address = editedUser.Address;
//            user.Age = editedUser.Age;
//            user.Name = editedUser.Name;
//            user.Country = editedUser.Country;

//            database.SaveChanges();

//            return Ok();
//        }

//        // DELETE api/<PersonApiController>/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var user = database.Users.SingleOrDefault(x => x.Id == id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            database.Users.Remove(user);
//            database.SaveChanges();

//            return Ok();
//        }
//    }
//}
