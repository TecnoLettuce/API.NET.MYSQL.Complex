using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiMySQL.Data.Repositories;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers ()
        {
            return Ok(await _userRepository.GetAlllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            return Ok(await _userRepository.GetUserDetailsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser ([FromBody] User user)
        {
            // Validaciones 
            if (user == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _userRepository.InsertUserAsync(user);

            return Created("Created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {

            // Validaciones 
            if (user == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _userRepository.UpdateUserAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUserAsync(new User() { IdUser = id });

            return NoContent();
        }


    }
}
