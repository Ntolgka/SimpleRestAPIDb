using Week2_Assignment.Models;

namespace Week2_Assignment.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task<User> GetByIdAsync(int id);
    Task<List<User>> Create(User User);
    Task<User> Update(User User);
    Task<User> Delete(int id);
    Task<User> Patch(int id, User updatedFields);
    Task<User> Authenticate(string username, string password);
}