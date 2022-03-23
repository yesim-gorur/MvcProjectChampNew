using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectChampNew.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminvalues = adminManager.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminManager.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]//sayfam yüklendiği zaman çalış
        public ActionResult EditAdmin(int id)//kategoriyi güncelle önce güncellenecek kategoriyi bulmamız lazım

        {
            var adminvalue = adminManager.GetByID(id);//id değişkeninden gelen parametreye göre ilgili bilgileir buraya aldım
            return View(adminvalue);
        }
        [HttpPost]//sayfam yüklendiği zaman çalış
        public ActionResult EditAdmin(Admin p)//kategoriyi güncelle önce güncellenecek kategoriyi bulmamız lazım

        {
            adminManager.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}