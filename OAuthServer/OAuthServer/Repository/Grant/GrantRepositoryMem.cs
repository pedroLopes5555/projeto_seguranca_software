namespace OAuthServer.Repository.Grant;

public class GrantRepositoryMem : IGrantRepository
{
    private static HashSet<Guid> _grants = new HashSet<Guid>();
    private object _lockObject = new object();
    
    public void AddGrant(Guid grant)
    {
        lock (_lockObject)
        {
            _grants.Add(grant);
        }
    }
    
    public void RemoveGrant(Guid grant)
    {
        lock (_lockObject)
        {
            _grants.Remove(grant);
        }
    }
    
    public Guid? FindGrant(Guid grant)
    {
        lock (_lockObject)
        {
            return _grants.Contains(grant) ? grant : null;
        }
    }
}