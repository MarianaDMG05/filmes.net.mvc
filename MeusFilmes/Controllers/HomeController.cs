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
        List<Serie> series = GetSeries();
        List<Genero> genero = GetGeneros();
        ViewData["Generos"] = genero;
        return View(series);
    }

    public IActionResult Details(int id)
    {
        List<Serie> series = GetSeries();
        List<Genero> genero = GetGeneros();
        DetailsVM details = new () {
           Generos = genero,
           Atual = series.FirstOrDefault(p => p.Id == id),
           Anterior = series.OrderByDescending(p => p.Id).FirstOrDefault(p => p.Id< id),
           Proximo = series.OrderBy(p => p.Id).FirstOrDefault(p => p.Id > id),
        };
        return View(details);
    }

    private List<Serie> GetSeries()
    {
        using (StreamReader leitor = new("Data\\inf.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Serie>>(dados);
        }
    }

    private List<Genero> GetGeneros()
    {
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Genero>>(dados);
        }
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