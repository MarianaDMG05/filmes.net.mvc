using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MeusFilmes.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MeusFilmes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Serie> series =[];
        using (StreamReader leitor = new("Data\\inf.json"))
        {
            string dados = leitor.ReadToEnd();
            series = JsonSerializer.Deserialize<List<Serie>>(dados);
        }
        
        List<Genero> genero =[];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            genero = JsonSerializer.Deserialize<List<Genero>>(dados);
        }
        ViewData["Generos"] = genero;
        return View(series);
    }

    public IActionResult Details(int id)
    {
        List<Serie> series =[];
        using (StreamReader leitor = new("Data\\inf.json"))
        {
            string dados = leitor.ReadToEnd();
            series = JsonSerializer.Deserialize<List<Serie>>(dados);
        }
        
        List<Genero> genero =[];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            genero = JsonSerializer.Deserialize<List<Genero>>(dados);
        }
        ViewData["Generos"] = genero;
        var serie = series 
        .Where(p => p.Id == id)
        .FirstOrDefault();
        return View(serie);

    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
