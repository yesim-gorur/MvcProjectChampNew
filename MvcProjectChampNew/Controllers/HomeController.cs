using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectChampNew.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//listeleme metodu
        {
            return View();
        }

        public ActionResult About()//hakkında
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()//iletişim
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();//geriye bir sayfa döndürecek
        
        }
    }
}