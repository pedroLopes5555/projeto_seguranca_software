using Microsoft.EntityFrameworkCore;

namespace OAuthServer.Repository.Models;

public class OAuthContex : DbContext
{
    public DbSet<DbUser> Users { get; set; } = null!;
    
    public DbSet<DbClient> Clients { get; set; } = null!;
    
    public OAuthContex(DbContextOptions<OAuthContex> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    
}