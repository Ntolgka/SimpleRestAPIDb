using AutoMapper;
using Week2_Assignment.Models;
using Week2_Assignment.Schema.Songs.Requests;
using Week2_Assignment.Schema.Songs.Responses;

namespace Week2_Assignment.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Song, SongCreateResponse>();
        CreateMap<Song, SongUpdateResponse>();
        CreateMap<Song, SongDeleteResponse>();
        CreateMap<Song, SongGetResponse>();
        
        CreateMap<User, UserCreateResponse>();
        CreateMap<User, UserUpdateResponse>();
        CreateMap<User, UserDeleteResponse>();
        CreateMap<User, UserGetResponse>();
        
        
        CreateMap<SongCreateRequest, Song>();
        CreateMap<SongUpdateRequest, Song>();
        CreateMap<SongGetRequest, Song>();
        CreateMap<SongDeleteRequest, Song>();
        
        CreateMap<UserCreateRequest, User>();
        CreateMap<UserUpdateRequest, User>();
        CreateMap<UserGetRequest, User>();
        CreateMap<UserDeleteRequest, User>();
    }
}