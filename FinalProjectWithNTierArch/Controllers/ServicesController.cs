using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
