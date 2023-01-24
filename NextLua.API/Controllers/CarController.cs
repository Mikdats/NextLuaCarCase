using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NextLua.Business.Abstract;
using NextLua.Entities.Concrete;
using NextLua.Entities.DTOs;
using System.Security.Claims;
using AutoMapper;
using NextLua.Core.Entities;

namespace NextLua.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CarController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ICarService _carService;
    private readonly IMapper _mapper;
    
    public CarController(ICarService carService, UserManager<IdentityUser> userManager, IMapper mapper)
    {
        _carService = carService;
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpPost] 
    [Route("addCar")]
    public IActionResult Add([FromBody] AddUpdateCarDto request)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var currentUserName = User.Identity.Name;
        var car = new Car
        {
            Model = request.Model,
            Color = request.Color,
            Price = request.Price,
            SellerId = currentUserID,
            SellerName = currentUserName
        };
        _carService.Add(car);
        return Ok();
    }
    
    [HttpPut]
    [Route("updateCar")]
    public IActionResult Update(int id, [FromBody] AddUpdateCarDto request)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var car = _carService.GetAll().Where(x => x.SellerId == currentUserID && x.Id==id).FirstOrDefault();
        if (car.Payment > 0)
            return BadRequest("You can't update car while in a purchase process");
        
        car.Model = request.Model;
        car.Color = request.Color;
        car.Price = request.Price;
        
        _carService.Update(car);
        return Ok();
    }
    
    [HttpGet]
    [Route("get")]
    public ActionResult<CarResponseDto> Get(int id)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var car= _carService.GetAll().FirstOrDefault(x => x.SellerId == currentUserID && x.Id == id);
        if (car == null)
            return BadRequest("There isn't a car with this Id");
        var carDto = _mapper.Map<CarResponseDto>(car);
        return Ok(carDto);
    }

    [HttpGet]
    [Route("list")]
    public ActionResult<List<CarResponseDto>> List()
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var cars = _carService.GetAll().Where(x => x.SellerId == currentUserID);
        var carDtos = _mapper.Map<List<CarResponseDto>>(cars);
        return Ok(carDtos);

    }
    
    [HttpDelete]
    [Route("delete")]
    public IActionResult Delete(int id)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var car = _carService.GetAll().Where(x => x.SellerId == currentUserID && x.Id==id).FirstOrDefault();
        _carService.Delete(car);
        return Ok();
    }
}