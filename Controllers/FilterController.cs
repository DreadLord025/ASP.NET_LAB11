using LAB11.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LAB11.Controllers;

public class FilterController : Controller
{
    [ServiceFilter(typeof(ActionFilter))]
    [ServiceFilter(typeof(UserCounterFilter))]
    public IActionResult Index()
    {
        return View();
    }
}