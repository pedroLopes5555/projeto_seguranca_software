namespace OAuthServer.Exeptions;

public class InvalidInputException :Exception
{
    public InvalidInputException(String message) : base(message)
    {
        
    }
}