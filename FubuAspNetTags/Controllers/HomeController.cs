using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FubuAspNetTags.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var vm = new HomeIndexViewModel();
            vm.Name = "Freddy";
            vm.StartedOn = DateTime.Now;

            return View(vm);
        }

        public ActionResult About()
        {
            return View();
        }
    }
    
    public class HomeIndexViewModel
    {
        public DateTime StartedOn { get; set; }
        public string Name { get; set; }
    }
}
