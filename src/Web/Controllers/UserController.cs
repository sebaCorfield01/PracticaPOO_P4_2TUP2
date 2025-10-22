using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Services;
using Core.Dtos;
using System.Collections.Generic;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService = new UserService();

        // GET: /User
        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        // GET: /User/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound("Usuario no encontrado.");
            return Ok(user);
        }

        // POST: /User
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _userService.Create(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: /User/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User updatedUser)
        {
            var result = _userService.Update(id, updatedUser);
            if (!result) return NotFound("Usuario no encontrado.");
            return NoContent();
        }

        // DELETE: /User/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            if (!result) return NotFound("Usuario no encontrado.");
            return NoContent();
        }
    }
}
