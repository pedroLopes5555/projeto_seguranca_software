using Microsoft.EntityFrameworkCore;
using OAuthServer.Repository.Models;

namespace OAuthServer.Repository.ClientRepo;

public class ClientRepository : IClientRepository
{
    private readonly OAuthContex _context;

    public ClientRepository(OAuthContex context)
    {
        _context = context;
    }

    public async Task<DbClient> CreateClient(DbClient client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<DbClient?> GetClientById(Guid id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<DbClient?> GetClientByName(string name)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<DbClient?> GetClientBySecret(string secret)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.ClientSecret == secret);
    }


    public async Task<DbClient> UpdateClient(DbClient client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task DeleteClient(Guid id)
    {
        await _context.Clients.Where(a => a.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<DbClient>> GetAllClients()
    {
        return await _context.Clients.ToListAsync();
    }
    
}