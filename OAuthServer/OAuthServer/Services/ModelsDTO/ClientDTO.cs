namespace OAuthServer.Services.ModelsDTO
{
    public class ClientDTO
    {
        public required String Id { get; set; }
        public required String Name { get; set; }
        public required String ClientSecret { get; set; }
        public required String RedirectUri { get; set; }
    }
}
