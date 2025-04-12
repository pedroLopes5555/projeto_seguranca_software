using System.ComponentModel.DataAnnotations;

namespace OAuthServer.Repository.Models;

public class DbClient
{
    [Key]
    public required Guid Id { get; set; }
    
    [Required, MaxLength(100)] 
    public required  string Name { get; set; }
    
    [Required, MaxLength(512)]
    public required String ClientSecret { get; set; }
    
    [Required, MaxLength(512)]
    public required String RedirectUri { get; set; }
    
    
}