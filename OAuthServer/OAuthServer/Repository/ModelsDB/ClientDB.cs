using System.ComponentModel.DataAnnotations;

namespace OAuthServer.Repository.ModelsDB;

public class ClientDB
{
    [Key]
    public required Guid Id { get; set; }
    
    [Required, MaxLength(100)] 
    public required  String Name { get; set; }
    
    [Required, MaxLength(512)]
    public required String ClientSecret { get; set; }
    
    [Required, MaxLength(512)]
    public required String RedirectUri { get; set; }
    
    
}