using System;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("find/{id}")]
        public IActionResult Find(String id)
        {
            var item = userRepository.Find(id);
            if (item == null)
            {
                return NotFound("User with id " + id + " was not found");
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPut("insert")]
        public IActionResult Insert([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("No user data provided");
            }
            if (user.UserName == null)
            {
                return BadRequest("Username must not be null");
            }
            if (user.Password == null)
            {
                return BadRequest("Password must not be null");
            }
            user.ID = Guid.NewGuid().ToString();
            userRepository.Insert(user);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(String id)
        {
            if (id == null)
            {
                return BadRequest("ID must not be null");
            }
            if (!userRepository.DoesUserExist(id))
            {
                return NotFound("User with id " + id + " was not found");
            }
            userRepository.Remove(id);
            return Ok();
        }

    }
}
