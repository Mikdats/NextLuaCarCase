using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NextLua.Entities.DTOs;
using NextLua.UI.Models.HomePage;
using NextLua.UI.Models.User;

namespace NextLua.UI.Controllers;

public class CustomerController:Controller
{
    public string BaseUrl { get; set; } ="https://localhost:7188/api/";

    [HttpGet]
    public async Task<IActionResult> WaitingApproval()
    {
        string url = $"{BaseUrl}Customer/waitingApproval";
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
    public async Task<IActionResult> SoldCars()
    {
        string url = $"{BaseUrl}Customer/soldCars";
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
    
    [HttpGet]
    public async Task<IActionResult> BoughtCars()
    {
        string url = $"{BaseUrl}Customer/boughtCars";
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

}