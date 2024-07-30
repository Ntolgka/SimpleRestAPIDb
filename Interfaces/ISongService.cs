using Week2_Assignment.Models;
using Week2_Assignment.Schema.Songs.Requests;
using Week2_Assignment.Schema.Songs.Responses;

namespace Week2_Assignment.Interfaces;

public interface ISongService
{
    Task<List<SongGetResponse>> GetAll();
    Task<SongGetResponse> GetByIdAsync(int id);
    Task<List<SongGetResponse>> GetClassics();
    Task<List<SongCreateResponse>> Create(SongCreateRequest request);
    Task<SongUpdateResponse> Update(SongUpdateRequest request);
    Task<SongDeleteResponse> Delete(int id);
    Task<Song> Patch(int id, Song updatedFields);
    Task<List<SongGetResponse>> ListByAlbum(string album);

}