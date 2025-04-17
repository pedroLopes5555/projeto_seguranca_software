using Microsoft.EntityFrameworkCore;

namespace OAuthServer.Repository.ModelsDB;

public class OAuthContex : DbContext
{
    public DbSet<UserDB> Users { get; set; } = null!;
    
    public DbSet<ClientDB> Clients { get; set; } = null!;
    
    public OAuthContex(DbContextOptions<OAuthContex> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    
}