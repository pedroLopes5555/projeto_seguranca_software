namespace OAuthServer.Repository.GrantIdRepository;

public interface IGrantIdRepository
{

    public void AddGrantUserId(Guid grantId, Guid clientId);
    public Guid? FindUserIdByGrant(Guid grantId);
}