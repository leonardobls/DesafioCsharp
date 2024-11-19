using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DesafioTecnicoProcessoSeletivo.Models;
using DesafioTecnicoProcessoSeletivo.Data;

namespace DesafioTecnicoProcessoSeletivo.Site.Controllers;

[Route("/")]
public class HomeController : Controller
{

    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
}
