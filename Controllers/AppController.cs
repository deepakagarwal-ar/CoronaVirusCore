using DeepakGallery.Data;
using DeepakGallery.Services;
using DeepakGallery.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;
        private readonly IGalleryRepository repository;

        public AppController(IMailService mailService, IGalleryRepository repository)
        {
            this.mailService = mailService;
            this.repository = repository;
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

        public IActionResult Shop()
        {
            //var result = this.repository.GetAllProducts();

            return View();
        }

        [HttpGet]
        public IActionResult Orders()
        {
            return Redirect("http://localhost:8888/App/shop#/Orders");
        }

    }
}
