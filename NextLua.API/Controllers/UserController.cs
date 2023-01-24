using AutoMapper;
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
    private readonly IMapper _mapper;

    public UserController(UserManager<IdentityUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("userlist")]
    public async Task<ActionResult> List()
    {
        var users = await _userManager.Users.ToListAsync();
        var userDtos = _mapper.Map<List<UserDto>>(users);
        return Ok(userDtos);
    }
}