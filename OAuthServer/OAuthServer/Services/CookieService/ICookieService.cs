namespace OAuthServer.Services.CookieService
{
    /// <summary>
    /// Interface for managing authentication cookie session.
    /// </summary>
    public interface ICookieService
    {
        /// <summary>
        /// Creates and stores an authentication cookie for the user after successful login.
        /// </summary>
        /// <param name="httpContext">Current HTTP context of the request.</param>
        /// <param name="userId">Unique identifier of the authenticated user.</param>
        /// <param name="username">Username of the authenticated user.</param>
        Task CreateAuthenticationCookieAsync(HttpContext httpContext, Guid userId, string username);

        /// <summary>
        /// Checks if the current HTTP context has a valid authenticated user session.
        /// </summary>
        /// <param name="httpContext">Current HTTP context of the request.</param>
        bool IsUserLoggedIn(HttpContext httpContext);

        string GetUserIdFromCookie(HttpContext httpContext);
    }
}
