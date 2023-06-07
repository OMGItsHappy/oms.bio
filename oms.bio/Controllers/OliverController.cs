using Microsoft.AspNetCore.Mvc;
using oms.bio.Helpers;

namespace oms.bio.Controllers
{
    public class OliverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Me()
        {

            return View();
        }
    }
}
