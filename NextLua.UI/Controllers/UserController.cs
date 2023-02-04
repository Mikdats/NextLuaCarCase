using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NextLua.Entities.DTOs;
using NextLua.UI.Models.HomePage;
using NextLua.UI.Models.User;

namespace NextLua.UI.Controllers;

public class UserController :Controller
{
    public string BaseUrl { get; set; } ="https://localhost:7188/api/";
    
    [HttpGet]
    public async Task<IActionResult> Users()
    {
        var token = HttpContext.Session.GetString("token");
        
        string url = $"{BaseUrl}User/userlist";
        List<UserDto> users = new List<UserDto>();
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", token);
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                users = (JsonConvert.DeserializeObject<List<UserDto>>(apiResponse) ?? throw new InvalidOperationException("Kullanıcı bulunamadı")).ToList();
            }
            var list= new UserVM()
            {
                Users = users
            };
        
            return View(list);
        }
    }
    
}