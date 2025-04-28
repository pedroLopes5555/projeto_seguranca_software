namespace OAuthServer.Repository.GrantIdRepository;

public class GrantIdMemRepository : IGrantIdRepository
{
    private Dictionary<Guid, Guid> _grantIds = new Dictionary<Guid, Guid>();

    
    public void AddGrantUserId(Guid grantId, Guid clientId)
    {
        if (_grantIds.ContainsKey(grantId))
        {
            throw new Exception("Grant ID already exists");
        }
        
        _grantIds[grantId] = clientId;
    }
    public Guid? FindUserIdByGrant(Guid grantId)
    {
        return _grantIds[grantId];
    }
}