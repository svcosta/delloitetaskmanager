using Delloite.TaskManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Delloite Task Manager";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Any question you may  have, please email me: sergio.vc@hotmail.com";

            return View();
        }
    }
}