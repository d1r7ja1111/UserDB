using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services.interfaces;


namespace Project2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbUserController(IUserRepository _repo) : ControllerBase
    {
<<<<<<< Updated upstream
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10) //Pagination
=======
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? sortBy) //Tagad, kontroleris ir tikai pieprasījumu routēšanai
>>>>>>> Stashed changes
        {
            var users = await _repo.GetAllUsers();
            var paged = users.Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(paged);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _repo.GetUserById(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            var id = await _repo.Create(user);
            return CreatedAtAction(nameof(Get), new { id }, user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UserModel user)
        {
            if (id != user.Id) return BadRequest("ID incorrect!");
            await _repo.Update(user);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}
