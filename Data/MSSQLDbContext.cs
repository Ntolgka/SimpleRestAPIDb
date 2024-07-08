using Microsoft.EntityFrameworkCore;
using Week2_Assesment.Models;

namespace Week2_Assessment.Data;

public class MSSQLDbContext : DbContext
{
    public MSSQLDbContext(DbContextOptions<MSSQLDbContext> options) : base(options)
    {
        
    }

    public DbSet<Song> Songs { get; set; }
    
}