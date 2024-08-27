using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrontendMVC.Models;

public class TrBpkbController : Controller
{
    private readonly HttpClient _httpClient;

    public TrBpkbController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("https://localhost:5001/api/storage-locations");
        var locations = await response.Content.ReadAsAsync<IEnumerable<MsStorageLocation>>();

        ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Save(TrBpkb trBpkb)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/trbpkb", trBpkb);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View("Index", trBpkb);
    }

    public IActionResult Cancel()
    {
        return RedirectToAction("Logoff", "Account");
    }
}
