using Microsoft.EntityFrameworkCore;
using Week2_Assesment.Interfaces;
using Week2_Assesment.Models;
using Week2_Assessment.Data;

namespace Week2_Assesment.Services;

public class SongService : ISongService
{
    //private readonly List<Song> songs;
    private readonly MSSQLDbContext _context;

    public SongService(MSSQLDbContext context)
    {
        _context = context;
        
        // Id, Band, Name, Album, ReleaseDate
        // songs = new List<Song>
        // {
        //     new Song {Id = 1, Band = "Metallica", Name = "Turn the Page", Album = "Garage Inc.", ReleaseDate = 1998},
        //     new Song {Id = 21, Band = "Megadeth", Name = "Tornado of Souls", Album = "Rust in Peace", ReleaseDate = 1990},
        //     new Song {Id = 3, Band = "Camel", Name = "Stationary Traveller", Album = "Stationary Traveller", ReleaseDate = 1984},
        //     new Song {Id = 4, Band = "W.A.S.P.", Name = "Miss You", Album = "Golgotha", ReleaseDate = 2015},
        //     new Song {Id = 5, Band = "Porcupine Tree", Name = "Anesthetize", Album = "Fear of a Blank Planet", ReleaseDate = 1998},
        //     new Song {Id = 6, Band = "Katatonia", Name = "July", Album = "", ReleaseDate = 2007},
        //     new Song {Id = 7, Band = "Megadeth", Name = "Lucretia", Album = "Rust in Peace", ReleaseDate = 1990}
        // };
    }

    public async Task<List<Song>> GetAll()
    {
        List<Song> sortedSongs = songs.OrderBy(x => x.Band).ToList<Song>();
        return sortedSongs;
    }

    public async Task<Song> GetByIdAsync(int id)
    {
        return await _context.Songs.FirstOrDefaultAsync(x => x.Id == id);
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
            
        songs.Add(song);
        return songs;
    }
    
    public async Task<Song> Update(Song song)
    {
        Song selectedSong = songs.FirstOrDefault(x => x.Id == song.Id);
        
        if (selectedSong is null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }

        selectedSong.Band = song.Band;
        selectedSong.Name = song.Name;
        selectedSong.Album = song.Album;
        selectedSong.ReleaseDate = song.ReleaseDate;
        
        return selectedSong;
    }
    
    public async Task<Song> Delete(int id)
    {
        Song song = songs.FirstOrDefault(x => x.Id == id);
        if (song == null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }
        songs.Remove(song);
        return song;
    }
    
    public async Task<Song> Patch(int id, Song updatedFields)
    {
        Song song = songs.FirstOrDefault(x => x.Id == id);
    
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
    
        if (updatedFields.ReleaseDate != 0)
        {
            song.ReleaseDate = updatedFields.ReleaseDate;
        }
    
        return song;
    }
    
    public async Task<List<Song>> ListByAlbum(string album)
    {
        List<Song> listedSongs = songs.FindAll(x => x.Album == album).OrderBy(x => x.Id).ToList<Song>();
        return listedSongs;
    }

}