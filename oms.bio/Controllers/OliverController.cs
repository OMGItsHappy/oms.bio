using Microsoft.AspNetCore.Mvc;
using oms.bio.Helpers;
using System.ComponentModel;
using System.Net.Mail;

namespace oms.bio.Controllers
{
    public class OliverController : Controller
    {
        [DisplayName("My Index")]
        private IActionResult Index()
        {
            return View();
        }
        [DisplayName("About Me")]
        public IActionResult Me()
        {
            MyFunctions.GetMethods("OliverController");
            return View();
        }
    }
}
