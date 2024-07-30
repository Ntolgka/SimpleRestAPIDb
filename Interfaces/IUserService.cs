using Week2_Assignment.Models;
using Week2_Assignment.Schema.Songs.Requests;
using Week2_Assignment.Schema.Songs.Responses;

namespace Week2_Assignment.Interfaces;

public interface IUserService
{
    Task<List<UserGetResponse>> GetAll();
    Task<UserGetResponse> GetByIdAsync(int id);
    Task<List<UserGetResponse>> Create(UserCreateRequest userCreateRequest);
    Task<UserGetResponse> Update(UserUpdateRequest userUpdateRequest);
    Task<UserGetResponse> Delete(int id);
    Task<UserGetResponse> Patch(int id, UserUpdateRequest updatedFields);
    Task<UserGetResponse> Authenticate(string username, string password);
}