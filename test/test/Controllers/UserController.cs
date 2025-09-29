using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Services.interfaces;

namespace test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService _userService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetUsers() =>
            Ok(await _userService.GetAllUsers());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id) //apskatit pec id
        {
            var user = await _userService.GetUserById(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user) //izveidot
        {
            var id = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id }, user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UserModel user) //upd
        {
            if (id != user.Id) return BadRequest("ID mismatch.");
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id) //del
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
