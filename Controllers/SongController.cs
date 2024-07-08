using Microsoft.AspNetCore.Mvc;
using Week2_Assesment.Interfaces;
using Week2_Assesment.Models;

namespace Week2_Assesment.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var songs = await _songService.GetAll();
        return Ok(songs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var song = await _songService.GetByIdAsync(id);
        if (song == null)
        {
            return NotFound("There is no song with the given id.");
        }
        return Ok(song);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Song song)
    {
        if (song == null)
        {
            return BadRequest();
        }
        
        try
        {
            var songs = await _songService.Create(song);
            return Ok(songs);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Song song)
    {
        if (song == null || id != song.Id)
        {
            return BadRequest("Id cannot be changed.");
        }

        try
        {
            var updatedSong = await _songService.Update(song);
            return Ok(updatedSong);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var song = await _songService.Delete(id);
            return Ok(song);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] Song updatedFields)
    {
        try
        {
            var updatedSong = await _songService.Patch(id, updatedFields);
            return Ok(updatedSong);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    // For instance, try the endpoint: /api/Songs/ListByAlbum?album=Rust%20in%20Peace
    [HttpGet("ListByAlbum")]
    public async Task<IActionResult> ListByAlbum([FromQuery] string album)
    {
        var songs = await _songService.ListByAlbum(album);
        return Ok(songs);
    }
    
}