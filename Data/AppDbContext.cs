using Microsoft.EntityFrameworkCore;
using Week2_Assignment.Models;

namespace Week2_Assignment.Data;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Song> Songs { get; set; }
    public DbSet<User> Users { get; set; }
    
}