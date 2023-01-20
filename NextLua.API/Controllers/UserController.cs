using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextLua.Entities.DTOs;

namespace NextLua.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    [Route("userlist")]
    public async Task<List<UserDto>> List()
    {
        return await _userManager.Users.Select(x=>new UserDto()
        {
            Email = x.Email,
            UserName = x.UserName
        }).ToListAsync();
    }
}