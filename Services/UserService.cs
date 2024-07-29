using Microsoft.EntityFrameworkCore;
using Week2_Assesment.Interfaces;
using Week2_Assesment.Models;
using Week2_Assessment.Data;

namespace Week2_Assesment.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    
    public  UserService(AppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<User>> GetAll()
    {
        List<User> sortedUsers = _context.Users.OrderBy(x => x.Id).ToList<User>();
        return sortedUsers;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        User User = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (User == null)
        {
            throw new KeyNotFoundException("There is no User with the given Id.");
        }

        return User;
    }
    
    public async Task<List<User>> Create(User User)
    {
        if (User == null)
        {
            throw new ArgumentNullException(nameof(User));
        }
            
        _context.Users.Add(User);
        await _context.SaveChangesAsync();
        return _context.Users.ToList();
    }
    
    public async Task<User> Update(User User)
    {
        User selectedUser = _context.Users.FirstOrDefault(x => x.Id == User.Id);
        
        if (selectedUser is null)
        {
            throw new KeyNotFoundException("There is no User with the given Id.");
        }
        
        selectedUser.Id = User.Id;
        selectedUser.Username = User.Username;
        selectedUser.Password = User.Password;
        
        await _context.SaveChangesAsync();
        
        return selectedUser;
    }
    
    public async Task<User> Delete(int id)
    {
        User user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            throw new KeyNotFoundException("There is no User with the given Id.");
        }
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
        return user;
    }
    
    public async Task<User> Patch(int id, User updatedFields)
    {
        User User = _context.Users.FirstOrDefault(x => x.Id == id);
    
        if (User == null)
        {
            throw new KeyNotFoundException("There is no User with the given Id.");
        }

        if (updatedFields.Id != null)
        {
            User.Id = updatedFields.Id;
        }
    
        if (!string.IsNullOrEmpty(updatedFields.Username))
        {
            User.Username = updatedFields.Username;
        }
    
        if (!string.IsNullOrEmpty(updatedFields.Password))
        {
            User.Password = updatedFields.Password;
        }
        
        await _context.SaveChangesAsync();
    
        return User;
    }
    
    public async Task<List<User>> ListByName(string name)
    {
        List<User> listedUsers = _context.Users.Where(x => x.Username == name).OrderBy(x => x.Id).ToList<User>();
        return listedUsers;
    }
    
}