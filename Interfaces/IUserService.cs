using Week2_Assesment.Models;

namespace Week2_Assesment.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task<User> GetByIdAsync(int id);
    Task<List<User>> Create(User User);
    Task<User> Update(User User);
    Task<User> Delete(int id);
    Task<User> Patch(int id, User updatedFields);
}