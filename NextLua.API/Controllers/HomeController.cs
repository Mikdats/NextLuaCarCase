using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NextLua.Business.Abstract;
using NextLua.Entities.Concrete;

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
        public List<Car> ListCars()
        {
            // var cars = _carService.GetCarsWithUser();
            return _carService.GetAll().Where(x=>x.BuyerId ==null).ToList();
        }
    }
}
