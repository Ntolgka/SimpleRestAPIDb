using Microsoft.AspNetCore.Mvc;
using Week2_Assignment.Interfaces;
using Week2_Assignment.Models;
using Week2_Assignment.Schema.Songs.Requests;

namespace Week2_Assignment.Controllers;

[ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest userCreateRequest)
        {
            var users = await _userService.Create(userCreateRequest);
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            var updatedUser = await _userService.Update(userUpdateRequest);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.Delete(id);
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UserUpdateRequest updatedFields)
        {
            var updatedUser = await _userService.Patch(id, updatedFields);
            return Ok(updatedUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            var user = await _userService.Authenticate(loginRequest.Username, loginRequest.Password);

            if (user != null)
            {
                return Ok(new { Message = "Login successful!", User = user });
            }

            return Unauthorized("Username or password is incorrect.");
        }
    }