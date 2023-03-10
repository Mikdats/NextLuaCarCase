using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NextLua.Entities.DTOs;
using NextLua.UI.Models.HomePage;

namespace NextLua.UI.Controllers;

public class HomePageController :Controller
{
    public string BaseUrl { get; set; } ="https://localhost:7188/api/";
    
    [HttpGet]
    public async Task<IActionResult> AllSoldCars()
    {
        
        string url = $"{BaseUrl}Home/allSoldCars";
        List<CarResponseDto> cars = new List<CarResponseDto>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<CarResponseDto>>(apiResponse).ToList();
       
            }
            var list= new CarResponseVM()
            {
                Cars = cars
            };
        
            return View(list);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> ListCars()
    {
        string url = $"{BaseUrl}Home/listCars";
        List<CarResponseDto> cars = new List<CarResponseDto>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<CarResponseDto>>(apiResponse).ToList();
       
            }
            var list= new CarResponseVM()
            {
                Cars = cars
            };
        
            return View(list);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> AllSoldCarsWithBuyerName()
    {
        string url = $"{BaseUrl}Home/allSoldCarsWithBuyerName";
        List<BoughtCarDto> cars = new List<BoughtCarDto>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<BoughtCarDto>>(apiResponse).ToList();
       
            }
            var list= new BoughtCarVM()
            {
                Cars = cars
            };
            return View(list);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> AllSoldCarsWithSellerName()
    {
        string url = $"{BaseUrl}Home/allSoldCarsWithSellerName";
        List<SoldCarDto> cars = new List<SoldCarDto>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<SoldCarDto>>(apiResponse).ToList();
       
            }
            var list= new SoldCarVM()
            {
                Cars = cars
            };
            return View(list);
        }
    }

}