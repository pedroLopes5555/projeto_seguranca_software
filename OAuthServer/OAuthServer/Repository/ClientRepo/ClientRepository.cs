using Microsoft.EntityFrameworkCore;
using OAuthServer.Repository.ModelsDB;

namespace OAuthServer.Repository.ClientRepo;

public class ClientRepository : IClientRepository
{
    private readonly OAuthContex _context;

    public ClientRepository(OAuthContex context)
    {
        _context = context;
    }

    public async Task<ClientDB?> CreateClient(ClientDB client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientDB?> GetClientById(Guid id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<ClientDB?> GetClientByName(string name)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<ClientDB?> GetClientBySecret(string secret)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.ClientSecret == secret);
    }


    public async Task<ClientDB?> UpdateClient(ClientDB client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task DeleteClient(Guid id)
    {
        await _context.Clients.Where(c => c.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<ClientDB>> GetAllClients()
    {
        return await _context.Clients.ToListAsync();
    }
}