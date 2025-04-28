namespace OAuthServer.Repository.GrantIdRepository;

public interface IGrantIdRepository
{

    void AddGrantUserId(Guid grantId, Guid clientId);
    Guid? FindUserIdByGrant(Guid grantId);
    void RemoveGrant(Guid grantId);
    bool CheckGrant(Guid grant);
}