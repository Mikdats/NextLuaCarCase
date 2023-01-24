using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listcars")]
        public async Task<ActionResult> ListCars()
        {
            var cars = _carService.GetAll().Where(x=>x.BuyerId==null);
            var carDtos = _mapper.Map<List<CarResponseDto>>(cars);
            return Ok(carDtos);
        }
        
        [HttpGet]
        [Route("allSoldCars")]
        public async Task<ActionResult> AllSoldCars()
        {
            var cars = _carService.GetAll().Where(x => x.PurchaseStatus == Enums.PurchaseStatus.Approved);
            var carDtos = _mapper.Map<List<CarResponseDto>>(cars);
            return Ok(carDtos);
        }
        
        [HttpGet]
        [Route("allSoldCarsWithBuyerName")]
        public async Task<ActionResult> AllSoldCarsWithBuyerName()
        {
            var cars= _carService.GetAll().Where(x => x.PurchaseStatus == Enums.PurchaseStatus.Approved);
            var carDtos = _mapper.Map<List<BoughtCarDto>>(cars);
            return Ok(carDtos);
        }
        
        [HttpGet]
        [Route("all" +
               "SoldCarsWithSellerName")]
        public async Task<ActionResult> AllSoldCarsWithSellerName()
        {
            var cars= _carService.GetAll().Where(x => x.PurchaseStatus == Enums.PurchaseStatus.Approved);
            var carDtos = _mapper.Map<List<SoldCarDto>>(cars);
            return Ok(carDtos);
        }
    }
}
