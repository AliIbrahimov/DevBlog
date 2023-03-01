using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
