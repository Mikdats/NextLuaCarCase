using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NextLua.Entities.DTOs;
using NextLua.UI.Models.HomePage;

namespace NextLua.UI.Controllers;

public class HomePageController :Controller
{
    [HttpGet]
    public async Task<IActionResult> AllSoldCars()
    {
        string url = "https://localhost:7188/api/Home/allSoldCars";
        List<CarResponseDto> cars = new List<CarResponseDto>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<CarResponseDto>>(apiResponse).ToList();
       
            }
            var list= new HomePageVM()
            {
                Cars = cars
            };
        
            return View(list);
        }
    }
}