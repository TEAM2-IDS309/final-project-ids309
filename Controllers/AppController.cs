using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalProjectIDS309.Models;

namespace FinalProjectIDS309.Controllers;

public class AppController : Controller
{
  private readonly ILogger<AppController> _logger;

  public AppController(ILogger<AppController> logger)
  {
    _logger = logger;
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
