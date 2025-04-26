namespace OAuthServer.Exeptions;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}