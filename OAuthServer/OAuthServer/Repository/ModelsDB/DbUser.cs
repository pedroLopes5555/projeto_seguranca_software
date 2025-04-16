using System.ComponentModel.DataAnnotations;

namespace OAuthServer.Repository.Models;

public class DbUser
{
    [Key]
    public required Guid Id { get; set; }
    
    [Required, MaxLength(100)]
    public required String Username { get; set; }
    
    [Required, MaxLength(512)]
    public required String PasswordHash { get; set; }
    
}