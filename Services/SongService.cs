using Microsoft.EntityFrameworkCore;
using Week2_Assignment.Interfaces;
using Week2_Assignment.Models;
using Week2_Assignment.Data;

namespace Week2_Assignment.Services;

public class SongService : ISongService
{
    private readonly AppDbContext _context;

    public SongService(AppDbContext context)
    {
        _context = context;
        
    }

    public async Task<List<Song>> GetAll()
    {
        List<Song> sortedSongs = _context.Songs.OrderBy(x => x.Band).ToList<Song>();
        return sortedSongs;
    }

    public async Task<Song> GetByIdAsync(int id)
    {
        Song song = await _context.Songs.FirstOrDefaultAsync(x => x.Id == id);
        if (song == null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }

        return song;
    }
    
    public async Task<List<Song>> Create(Song song)
    {
        if (song == null)
        {
            throw new ArgumentNullException(nameof(song));
        }
        
        if (string.IsNullOrWhiteSpace(song.Album))
        {
            song.Album = "Single";
        }
            
        _context.Songs.Add(song);
        await _context.SaveChangesAsync();
        return _context.Songs.ToList();
    }
    
    public async Task<Song> Update(Song song)
    {
        Song selectedSong = _context.Songs.FirstOrDefault(x => x.Id == song.Id);
        
        if (selectedSong is null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }

        selectedSong.Band = song.Band;
        selectedSong.Name = song.Name;
        selectedSong.Album = song.Album;
        selectedSong.ReleaseYear = song.ReleaseYear;
        
        await _context.SaveChangesAsync();
        
        return selectedSong;
    }
    
    public async Task<Song> Delete(int id)
    {
        Song song = _context.Songs.FirstOrDefault(x => x.Id == id);
        if (song == null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }
        _context.Songs.Remove(song);
        await _context.SaveChangesAsync();
        return song;
    }
    
    public async Task<Song> Patch(int id, Song updatedFields)
    {
        Song song = _context.Songs.FirstOrDefault(x => x.Id == id);
    
        if (song == null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }

        if (!string.IsNullOrEmpty(updatedFields.Band))
        {
            song.Band = updatedFields.Band;
        }
    
        if (!string.IsNullOrEmpty(updatedFields.Name))
        {
            song.Name = updatedFields.Name;
        }
    
        if (!string.IsNullOrEmpty(updatedFields.Album))
        {
            song.Album = updatedFields.Album;
        }
    
        if (updatedFields.ReleaseYear != 0)
        {
            song.ReleaseYear = updatedFields.ReleaseYear;
        }
        
        await _context.SaveChangesAsync();
    
        return song;
    }
    
    public async Task<List<Song>> ListByAlbum(string album)
    {
        List<Song> listedSongs = _context.Songs.Where(x => x.Album == album).OrderBy(x => x.Id).ToList<Song>();
        return listedSongs;
    }

}