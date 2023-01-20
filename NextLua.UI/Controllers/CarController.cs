using Microsoft.AspNetCore.Mvc;
using NextLua.Entities.Concrete;
using Newtonsoft.Json;
using NextLua.Entities.DTOs;
using NextLua.UI.Models;

namespace NextLua.UI.Controllers;

public class CarController:Controller
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
            
            ViewBag.cars = cars;
            return View();
    
        }
    }
}