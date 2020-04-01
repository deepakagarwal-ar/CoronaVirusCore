using CoronaVirusCore.Services;
using CoronaVirusCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaVirusCore.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;

        public AppController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send mail
                mailService.SendMessage(model.Email, model.Name, model.Subject, model.Message);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();

            }
            

            ViewBag.Title = "Contact us";
            return View();
        }

        [HttpGet]
        public IActionResult UtilizeCpu()
        {
            ViewBag.Title = "Utilize CPU";
            return View();
        }

        [HttpPost]
        public IActionResult UtilizeCpu(object model)
        {
            Util.Simple simple = new Util.Simple();

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";
            return View();
        }

    }
}
