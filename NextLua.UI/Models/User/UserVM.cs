using NextLua.Entities.DTOs;

namespace NextLua.UI.Models.User;

public class UserVM
{
    public List<UserDto> Users { get; set; } = new List<UserDto>();
}