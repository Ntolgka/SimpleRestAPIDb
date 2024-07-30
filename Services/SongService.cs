using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Week2_Assignment.Interfaces;
using Week2_Assignment.Models;
using Week2_Assignment.Data;
using Week2_Assignment.Extensions;
using Week2_Assignment.Schema.Songs.Requests;
using Week2_Assignment.Schema.Songs.Responses;

namespace Week2_Assignment.Services;

public class SongService : ISongService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SongService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        
    }

    public async Task<List<SongGetResponse>> GetAll()
    {
        List<Song> sortedSongs = await _context.Songs
            .OrderBy(x => x.Band)
            .ToListAsync();
        var mapped = _mapper.Map<List<SongGetResponse>>(sortedSongs);
        
        return mapped;
    }

    public async Task<SongGetResponse> GetByIdAsync(int id)
    {
        Song song = await _context.Songs.FirstOrDefaultAsync(x => x.Id == id);
        if (song == null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }
        
        var mapped = _mapper.Map<SongGetResponse>(song);
        mapped.IsClassic = song.IsClassic();

        return mapped;
    }
    
    public async Task<List<SongGetResponse>> GetClassics()
    {
        List<Song> allSongs = await _context.Songs.ToListAsync();
    
        var classicSongs = allSongs.Where(song => song.IsClassic()).ToList();
    
        var mappedSongs = _mapper.Map<List<SongGetResponse>>(classicSongs);
    
        return mappedSongs;
    }
    
    public async Task<List<SongCreateResponse>> Create(SongCreateRequest request)
    {
        var song = _mapper.Map<Song>(request);
        if (string.IsNullOrWhiteSpace(song.Album))
        {
            song.Album = "Single";
        }

        _context.Songs.Add(song);
        await _context.SaveChangesAsync();

        List<Song> songs = await _context.Songs.ToListAsync();
        var mapped = _mapper.Map<List<SongCreateResponse>>(songs);
        
        return mapped;
    }
    
    public async Task<SongUpdateResponse> Update(SongUpdateRequest request)
    {
        Song song = await _context.Songs.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (song == null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }

        _mapper.Map(request, song);
        await _context.SaveChangesAsync();
        
        var mapped = _mapper.Map<SongUpdateResponse>(song);

        return mapped;
    }
    
    public async Task<SongDeleteResponse> Delete(int id)
    {
        Song song = await _context.Songs.FirstOrDefaultAsync(x => x.Id == id);
        
        if (song == null)
        {
            throw new KeyNotFoundException("There is no song with the given Id.");
        }

        _context.Songs.Remove(song);
        await _context.SaveChangesAsync();
        
        var mapped = _mapper.Map<SongDeleteResponse>(song);

        return mapped;
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
    
    public async Task<List<SongGetResponse>> ListByAlbum(string album)
    {
        List<Song> listedSongs = await _context.Songs
            .Where(x => x.Album == album)
            .OrderBy(x => x.Id)
            .ToListAsync();
        
        var mapped = _mapper.Map<List<SongGetResponse>>(listedSongs);

        return mapped;
    }

}