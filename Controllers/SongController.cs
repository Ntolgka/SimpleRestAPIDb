using Microsoft.AspNetCore.Mvc;
using Week2_Assesment.Interfaces;
using Week2_Assesment.Models;
using Week2_Assessment.Extensions;

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
        
        var isClassic = song.IsClassic();
        return Ok(new 
        { 
            Song = song, 
            IsClassic = isClassic 
        });
    }
    
    [HttpGet("classics")]
    public async Task<IActionResult> GetClassics()
    {
        var songs = await _songService.GetAll();
        var classicSongs = songs.Where(song => song.IsClassic()).ToList();
        return Ok(classicSongs);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Song song)
    {
        var songs = await _songService.Create(song);
        return Ok(songs);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Song song)
    {
        var updatedSong = await _songService.Update(song);
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