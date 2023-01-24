using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NextLua.Business.Abstract;
using NextLua.Core.Entities;
using NextLua.Entities.DTOs;

namespace NextLua.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomerController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public CustomerController(ICarService carService, UserManager<IdentityUser> userManager, IMapper mapper)
    {
        _carService = carService;
        _userManager = userManager;
        _mapper = mapper;
    }
     [HttpPut]
    [Route("buyCar")]
    public IActionResult BuyCar(int id,decimal payment)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var currentUserName = User.Identity?.Name;
        var car = _carService.GetAll().FirstOrDefault(x => x.Id==id);
        
        if(car==null)
            return StatusCode(StatusCodes.Status500InternalServerError, "There isn't a car with this Id!");
        
        if(car.SellerId==currentUserID)
            return StatusCode(StatusCodes.Status500InternalServerError, "You can't buy your own car!");

        car.Payment += payment;
        car.BuyerId = currentUserID;
        car.BuyerName = currentUserName;
  
        if (car.Price - car.Payment > 0)
        {
            car.PaymentStatus = Enums.PaymentStatus.InProcess;
        }
        else
        {
            car.PaymentStatus = Enums.PaymentStatus.Completed;
            car.PurchaseStatus = Enums.PurchaseStatus.Waiting;
        }

        _carService.Update(car);
        return Ok();
    }

    [HttpPut]
    [Route("sellCar")]
    public IActionResult SellCar(int id)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var car = _carService.GetAll().FirstOrDefault(x => x.Id == id && x.SellerId==currentUserID);

        if (car == null)
            return StatusCode(StatusCodes.Status500InternalServerError, "There isn't a car with this Id!");

        if(car.Payment!=car.Price)
            return StatusCode(StatusCodes.Status500InternalServerError, "Purchase process still continue!");
        
        car.PurchaseStatus = Enums.PurchaseStatus.Approved;
        _carService.Update(car);
        return Ok();
    }
    
    [HttpGet]
    [Route("waitingApproval")]
    public ActionResult<List<CarResponseDto>> WaitingApproval()
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var cars = _carService.GetAll().Where(x => x.PurchaseStatus == Enums.PurchaseStatus.Waiting && x.SellerId == currentUserID);
        var carDtos = _mapper.Map<List<CarResponseDto>>(cars);

        if (!cars.Any())
            return StatusCode(StatusCodes.Status500InternalServerError, "There aren't any cars!");
        
        return  Ok(carDtos);
    }

    [HttpGet]
    [Route("soldCars")]
    public ActionResult<List<SoldCarDto>> SoldCars()
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var cars = _carService.GetAll().Where(x => x.PurchaseStatus == Enums.PurchaseStatus.Approved && x.SellerId == currentUserID);
        var carDtos = _mapper.Map<List<SoldCarDto>>(cars);
        
        if (!cars.Any())
            return StatusCode(StatusCodes.Status500InternalServerError, "There aren't any cars!");

        return Ok(carDtos);
    }

    [HttpGet]
    [Route("boughtCars")]
    public ActionResult<List<BoughtCarDto>> BoughtCars()
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var cars = _carService.GetAll().Where(x => x.PurchaseStatus == Enums.PurchaseStatus.Approved && x.BuyerId == currentUserID);
        var carDtos = _mapper.Map<List<BoughtCarDto>>(cars);
        
        if (!cars.Any())
            return StatusCode(StatusCodes.Status500InternalServerError, "There aren't any cars!");

        return Ok(carDtos);
    }

}