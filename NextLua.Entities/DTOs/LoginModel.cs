using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NextLua.Core.Entities;

namespace NextLua.Entities.DTOs;

public class LoginModel : IDto
{
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    
}