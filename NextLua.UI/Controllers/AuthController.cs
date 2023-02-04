using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NextLua.Entities.DTOs;

namespace NextLua.UI.Controllers;

public class AuthController : Controller
{
    public string BaseUrl { get; set; } = "https://localhost:7188/api/";

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        string url = $"{BaseUrl}Auth/register";

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            var postTask = client.PostAsJsonAsync("register", model);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
        }

        ModelState.AddModelError(string.Empty, "Server Error.");

        return View(model);
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        string url = $"{BaseUrl}Auth/login";

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("login", model);

            var tokenn = JObject.Parse(await response.Content.ReadAsStringAsync());

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokenn.GetValue("token").ToString());

            HttpContext.Session.SetString("token", tokenn.GetValue("token").ToString());
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Users", "User");
            }
        }
        ModelState.AddModelError(string.Empty, "Server Error.");

        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("token");
        return RedirectToAction("Login");
    }
}