using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NextLua.Business.Abstract;
using NextLua.Entities.Concrete;
using NextLua.Entities.DTOs;
using System.Security.Claims;
using NextLua.Core.Entities;

namespace NextLua.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CarController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ICarService _carService;

    public CarController(ICarService carService, UserManager<IdentityUser> userManager)
    {
        _carService = carService;
        _userManager = userManager;
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
    public Car Get(int id)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        return _carService.GetAll().Where(x => x.SellerId == currentUserID && x.Id==id).FirstOrDefault();
    }
    
    [HttpPut]
    [Route("buyCar")]
    public IActionResult BuyCar(int id,decimal payment)
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var currentUserName = User.Identity.Name;
        var car = _carService.GetAll().Where(x => x.Id==id).FirstOrDefault();
        
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
        var car = _carService.GetAll().Where(x => x.Id == id && x.SellerId==currentUserID).FirstOrDefault();

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
    public IActionResult WaitingApproval()
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var cars = _carService.GetAll().Where(x => x.PurchaseStatus==Enums.PurchaseStatus.Waiting && x.SellerId==currentUserID).ToList();

        if (!cars.Any())
            return StatusCode(StatusCodes.Status500InternalServerError, "There aren't any cars!");
        
        return  Ok(cars);
    }

    [HttpGet]
    [Route("list")]
    public List<Car> List()
    {
        var currentUserID = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        return _carService.GetAll().Where(x => x.SellerId == currentUserID).ToList();
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