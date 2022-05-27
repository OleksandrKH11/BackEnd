using AspNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly UsersServise movies;

        public UsersController(UsersServise movies)
        {
            this.movies = movies;
        }

        [HttpGet("getUsers")]
        public async Task<List<User>> GetUsers()
        {
            var data = await movies.Get();
            return data;
        }

        [HttpGet("getUserById")]
        public async Task<User> GetUserById(string id)
        {
            var data = await movies.Get(id);
            return data;
        }

        [HttpPost("createUser")]
        public async Task<ActionResult> CreateUser([FromBody] User newMovie)
        {
            await movies.Create(newMovie);
            return Ok();
        }

        [HttpPut("updateUser")]
        public async Task UpdateUser(string id, User updateMovie)
        {
            await movies.Update(id, updateMovie);
        }

        [HttpDelete("deleteUser")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await movies.Remove(id);
            return Ok();
        }
    }
}
