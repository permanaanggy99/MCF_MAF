using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using FrontendMVC.Models;

public class AccountController : Controller
{
    private readonly HttpClient _httpClient;

    public AccountController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string userName, string password)
    {
        var response = await _httpClient.GetAsync($"https://localhost:5001/api/users/{userName}/{password}");
        if (response.IsSuccessStatusCode)
        {
            var user = await response.Content.ReadAsAsync<MsUser>();
            if (user != null && user.IsActive)
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction("Index", "TrBpkb");
            }
        }

        ViewBag.ErrorMessage = "User tidak ditemukan atau tidak aktif.";
        return View();
    }

    public IActionResult Logoff()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
