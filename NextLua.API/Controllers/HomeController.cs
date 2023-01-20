using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NextLua.Business.Abstract;
using NextLua.Core.Entities;
using NextLua.Entities.Concrete;
using NextLua.Entities.DTOs;

namespace NextLua.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {

        private readonly ICarService _carService;

        public HomeController(ICarService carService)
        {
            _carService = carService;
          
        }

        [HttpGet]
        [Route("listcars")]
        public List<CarResponseDto> ListCars()
        {
            return _carService.GetAll().Where(x=>x.BuyerId ==null).
                Select(x=>new CarResponseDto()
                {
                    CarId = x.Id,
                    Color = x.Color,
                    Model = x.Model,
                    Price = x.Price
                }).ToList();
        }
        
        [HttpGet]
        [Route("allSoldCars")]
        public List<CarResponseDto> AllSoldCars()
        {
            return _carService.GetAll().Where(x=>x.PurchaseStatus ==Enums.PurchaseStatus.Approved).
                Select(x=>new CarResponseDto()
                {
                    CarId = x.Id,
                    Color = x.Color,
                    Model = x.Model,
                    Price = x.Price
                }).ToList();
        }
        
        [HttpGet]
        [Route("allSoldCarsWithBuyerName")]
        public List<BoughtCarDto> AllSoldCarsWithBuyerName()
        {
            return _carService.GetAll().Where(x=>x.PurchaseStatus ==Enums.PurchaseStatus.Approved).
                Select(x=>new BoughtCarDto()
                {
                    Color = x.Color,
                    Model = x.Model,
                    Price = x.Price,
                    BuyerName = x.BuyerName
                }).ToList();
        }
        
        [HttpGet]
        [Route("allSoldCarsWithSellerName")]
        public List<SoldCarDto> AllSoldCarsWithSellerName()
        {
            return _carService.GetAll().Where(x=>x.PurchaseStatus ==Enums.PurchaseStatus.Approved).
                Select(x=>new SoldCarDto()
                {
                    Color = x.Color,
                    Model = x.Model,
                    Price = x.Price,
                    SellerName = x.SellerName
                }).ToList();
        }
    }
}
