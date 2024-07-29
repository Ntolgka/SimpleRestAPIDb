using Microsoft.EntityFrameworkCore;
using Week2_Assesment.Models;

namespace Week2_Assessment.Data;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Song> Songs { get; set; }
    
}