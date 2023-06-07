using Microsoft.AspNetCore.Mvc;
using oms.bio.Helpers;
using System.ComponentModel;
using System.Net.Mail;

namespace oms.bio.Controllers
{
    public class OliverController : Controller
    { //https://coolors.co/c2c094-a9a587-390040-730071-dc9596
        //https://coolors.co/ffa400-009ffd-2a2a72-232528-eaf6ff
        [DisplayName("About Me")]
        public IActionResult Me()
        {
            MyFunctions.GetMethods("OliverController");
            return View();
        }

        [DisplayName("My Resume")]
        public IActionResult Resume() 
        {
            return View();
        }
    }
}
