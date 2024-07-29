using Microsoft.AspNetCore.Mvc;
using Week2_Assesment.Interfaces;
using Week2_Assesment.Models;

namespace Week2_Assesment.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class UserController : ControllerBase
{
    private readonly IUserService _UserService;

    public UserController(IUserService UserService)
    {
        _UserService = UserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Users = await _UserService.GetAll();
        return Ok(Users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var User = await _UserService.GetByIdAsync(id);
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User User)
    {
        var Users = await _UserService.Create(User);
        return Ok(Users);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User User)
    {
        var updatedUser = await _UserService.Update(User);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var User = await _UserService.Delete(id);
        return Ok(User);
        
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] User updatedFields)
    {
        var updatedUser = await _UserService.Patch(id, updatedFields);
        return Ok(updatedUser);
        
    }
    
}