using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NextLua.Core.Entities;

namespace NextLua.Entities.DTOs;

public class RegisterModel: IDto
{
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    
    // [NotMapped, Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
    // public string PasswordRepeat { get; set; }
}


