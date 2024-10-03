using Microsoft.AspNetCore.Mvc;
using catedra1.Src.DTOs;
using catedra1.Src.Models;
using catedra1.src.Interfaces;
using catedra1.Src.Filters;
using catedra1.Src.Mappers;

namespace catedra1.Src.Controllers
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
        public IActionResult GetAll([FromQuery] UserFilter userFilter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = _userRepository.GetAll(userFilter);
            var usersDto = users.Select(u => u.ToGetUserDto());
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToGetUserDto());
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_userRepository.ExistsByRut(userDto.Rut))
            {
                return Conflict(new { message = "RUT already exists." });
            }

            var user = userDto.ToUserModel();
            var createdUser = _userRepository.Post(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser.ToGetUserDto());
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            if (existingUser.Rut != userDto.Rut && _userRepository.ExistsByRut(userDto.Rut))
            {
                return Conflict(new { message = "RUT already exists." });
            }

            var updatedUser = _userRepository.Put(id, userDto);
            if (updatedUser == null){
                return NotFound();
            }

            return Ok(updatedUser.ToGetUserDto());
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedUser = _userRepository.Delete(id);
            if (deletedUser == null)
            {
                return NotFound();
            }

            return Ok(deletedUser.ToGetUserDto());
        }
    }
}