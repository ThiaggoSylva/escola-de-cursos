using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
