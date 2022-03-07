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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()//kategorileri listeleyebilecegim metod

        {
            var categoryvalues = cm.GetList();//caregory values değişkenimin içine getall business layer ekleyecegim
            return View(categoryvalues);//bana bir view gönder bu view değişkendeki degerlerle gelsin

        }
        [HttpGet]// sayfa yüklendiğinde bu sayfa yüklenecek
        public ActionResult AddCategory()
        {
            return View();

        }
        [HttpPost]// butona basılırsa yeni kategori eklenecek
        public ActionResult AddCategory(Category p)// kategori ekleme işlemi yapacagım
        {
            //  cm.CategoryAddBL(p);
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult results = categoryValidatior.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); 
                }
            }
            return RedirectToAction("GetCategoryList");



        }


    }
}