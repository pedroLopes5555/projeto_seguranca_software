namespace OAuthServer.Exeptions;



public class NotFoundException : Exception
{
    public NotFoundException(String message) : base(message: message)
    {
        
    }
    
}