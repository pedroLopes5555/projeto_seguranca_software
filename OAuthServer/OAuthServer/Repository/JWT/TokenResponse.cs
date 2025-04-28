namespace OAuthServer.Repository.JWT;

public class TokenResponse
{
    public required string access_token { get; set; }
    public required  string token_type { get; set; }
    public required  int expires_in { get; set; }
    public required  string refresh_token { get; set; }
    
    /*
     *          "access_token": "the-jwt-or-token",
       "token_type": "Bearer",
       "expires_in": 3600,
       "refresh_token": "optional"
     */
}