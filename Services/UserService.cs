using Microsoft.EntityFrameworkCore;
using Week2_Assignment.Interfaces;
using Week2_Assignment.Models;
using Week2_Assignment.Data;
using Week2_Assignment.Helpers;

namespace Week2_Assignment.Services;

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
    
    public async Task<List<User>> Create(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
            
        user.Password = CryptoHelper.CreateMD5(user.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return await _context.Users.ToListAsync();
    }
    
    public async Task<User> Update(User user)
    {
        User selectedUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        
        if (selectedUser is null)
        {
            throw new KeyNotFoundException("There is no User with the given Id.");
        }
        
        selectedUser.Id = user.Id;
        selectedUser.Username = user.Username;
        selectedUser.Password = user.Password;
        
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
        User user = _context.Users.FirstOrDefault(x => x.Id == id);
    
        if (user == null)
        {
            throw new KeyNotFoundException("There is no User with the given Id.");
        }

        if (updatedFields.Id != null)
        {
            user.Id = updatedFields.Id;
        }
    
        if (!string.IsNullOrEmpty(updatedFields.Username))
        {
            user.Username = updatedFields.Username;
        }
    
        if (!string.IsNullOrEmpty(updatedFields.Password))
        {
            user.Password = updatedFields.Password;
        }
        
        await _context.SaveChangesAsync();
    
        return user;
    }
    
    public async Task<User> Authenticate(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user != null && user.Password == CryptoHelper.CreateMD5(password))
        {
            return user;
        }
        return null;
    }
    
}