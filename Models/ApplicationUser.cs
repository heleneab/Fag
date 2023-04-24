using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace test_4.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string? Name { get; set; } = String.Empty;
    
    public string? UserRoles { get; set; } = String.Empty;
}