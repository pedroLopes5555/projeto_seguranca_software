using OAuthServer.Repository.Grant;

namespace OAuthServer.Services.GrantService;

public class GrantService : IGrantService
{
    private readonly IGrantRepository _grantRepository;

    public GrantService(IGrantRepository grantRepository)
    {
        _grantRepository = grantRepository;
    }

    public Guid CreateGrant()
    {
        var guid = Guid.NewGuid();
        _grantRepository.AddGrant(guid);
        return guid;
    }

    public bool CheckGrant(Guid grant)
    {
        if (_grantRepository.FindGrant(grant) == null)
        {
            return false;
        }
        
        try{
            _grantRepository.RemoveGrant(grant);
        }catch(Exception ex){ 
            throw new Exception("Could not remove grant", ex);
        }
        
        return true;
    }
}