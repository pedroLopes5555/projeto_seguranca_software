namespace OAuthServer.Repository.Grant;

public interface IGrantRepository
{
    /// <summary>
    /// Defines methods for managing grant identifiers.
    /// </summary>

    /// <summary>
    /// Adds a new grant identifier to the repository.
    /// </summary>
    /// <param name="grant">The unique grant identifier to add.</param>
    void AddGrant(Guid grant);

    /// <summary>
    /// Removes a grant identifier from the repository.
    /// </summary>
    /// <param name="grant">The grant identifier to remove.</param>
    void RemoveGrant(Guid grant);

    /// <summary>
    /// Attempts to find a grant identifier in the repository.
    /// </summary>
    /// <param name="grant">The grant identifier to find.</param>
    /// <returns>
    /// The matching grant identifier if found; otherwise, <c>null</c>.
    /// </returns>
    Guid? FindGrant(Guid grant);

}