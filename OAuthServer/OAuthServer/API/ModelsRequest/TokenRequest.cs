namespace OAuthServer.API.ModelsRequest;

public class TokenRequest
{
    public required string grant_type { get; set; }
    public required Guid code { get; set; }
    public required string redirect_uri { get; set; }
    public required Guid client_id { get; set; }
    public required string client_secret { get; set; }
    
    
    
    //http://localhost:3000/callback?code=1f79f6b4-5fba-4c41-832e-1023708c5f39
    
    /*
        grant_type=authorization_code
       code=your-code-here
       redirect_uri=http://localhost:3000/callback
       client_id=your-client-id
       client_secret=your-client-secret
     */
}