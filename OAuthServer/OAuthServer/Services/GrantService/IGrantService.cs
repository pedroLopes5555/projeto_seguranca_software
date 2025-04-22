namespace OAuthServer.Services.GrantService;

/// <summary>
/// Interface for managing grant creation and validation.
/// </summary>
public interface IGrantService
{

    /// <summary>
    /// Creates and stores a new grant identifier.
    /// </summary>
    /// <returns>The newly created grant.</returns>
    Guid CreateGrant();

    /// <summary>
    /// Verifies and removes a grant if it exists.
    /// </summary>
    /// <param name="grant">The grant identifier to validate and remove.</param>
    /// <returns><c>true</c> if the grant was found and removed; otherwise, <c>false</c>.</returns>
    bool CheckGrant(Guid grant);
}