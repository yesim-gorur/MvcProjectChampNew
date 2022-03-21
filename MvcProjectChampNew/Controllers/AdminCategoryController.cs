using BusinessLayer;
using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectChampNew.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        [Authorize(Roles ="B")]// sadece b rolüne sahip olan kişiler bu alanı görsün
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult results = categoryValidatior.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();

        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View();
        }
        [HttpGet]//sayfam yüklendiği zaman çalış
        public ActionResult EditCategory(int id)//kategoriyi güncelle önce güncellenecek kategoriyi bulmamız lazım

        {
            var categoryvalue=cm.GetByID(id);//id değişkeninden gelen parametreye göre ilgili bilgileir buraya aldım
            return View(categoryvalue);
        }
        [HttpPost]//sayfam yüklendiği zaman çalış
        public ActionResult EditCategory(Category p)//kategoriyi güncelle önce güncellenecek kategoriyi bulmamız lazım

        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}