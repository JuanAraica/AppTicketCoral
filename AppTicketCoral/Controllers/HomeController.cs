using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTicketCoral.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult homeUsuarios()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult HomeSup()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HomeBayer()
        {
            ViewBag.Message = "Bayer Page";

            return View();
        }
        public ActionResult HomePops()
        {
            ViewBag.Message = "Pozuelo page.";

            return View();
        }
        public ActionResult HomeHeraeus()
        {
            ViewBag.Message = "Heraous";

            return View();
        }

    }
}