using Microsoft.AspNetCore.Mvc;
using Week2_Assesment.Interfaces;
using Week2_Assesment.Models;

namespace Week2_Assesment.Controllers;

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
    public async Task<IActionResult> Create([FromBody] User user)
    {
        var users = await _userService.Create(user);
        return Ok(users);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User user)
    {
        var updatedUser = await _userService.Update(user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userService.Delete(id);
        return Ok(user);
        
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] User updatedFields)
    {
        var updatedUser = await _userService.Patch(id, updatedFields);
        return Ok(updatedUser);
        
    }
    
    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login(string username,  string password)
    {
        var user = await _userService.Authenticate(username, password);

        if (user != null)
        {
            return Ok(new { Message = "Login successful!", User = user });
        }

        return Unauthorized("Username or password is incorrect.");
    }
    
}