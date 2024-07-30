using Microsoft.AspNetCore.Mvc;
using Week2_Assignment.Interfaces;
using Week2_Assignment.Models;
using Week2_Assignment.Extensions;
using Week2_Assignment.Schema.Songs.Requests;

namespace Week2_Assignment.Controllers;

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
        var songResponse = await _songService.GetByIdAsync(id);
        return Ok(songResponse);
    }
    
    [HttpGet("classics")]
    public async Task<IActionResult> GetClassics()
    {
        var classicSongs = await _songService.GetClassics();
        return Ok(classicSongs);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SongCreateRequest request)
    {
        var songs = await _songService.Create(request);
        return Ok(songs);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SongUpdateRequest request)
    {
        var updatedSong = await _songService.Update(request);
        return Ok(updatedSong);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var song = await _songService.Delete(id);
        return Ok(song);
        
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] Song updatedFields)
    {
        var updatedSong = await _songService.Patch(id, updatedFields);
        return Ok(updatedSong);
        
    }

    // For instance, try the endpoint: /api/Songs/ListByAlbum?album=Rust%20in%20Peace
    [HttpGet("ListByAlbum")]
    public async Task<IActionResult> ListByAlbum([FromQuery] string album)
    {
        var songs = await _songService.ListByAlbum(album);
        return Ok(songs);
    }
    
}