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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        public ActionResult Index()
        {
            var headingvalues = hm.GetList();//heading manager deki get list metodunu getireceksin
            return View(headingvalues);//ekran döndüreceksin o da headingvalues
        }
        [HttpGet]
        public ActionResult AddHeading()
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()


                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterId.ToString()

                                                }).ToList();
            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EditHeading(int id)//int id dememin nedeni şu sen birşeyi düzenleyeceksin ama neyi
            //belli bir id üzerinden düzenleme yapmalısın
        {
            //önce güncellenecek olan degeri bu sayfaya taşımam gerekiyor


            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()


                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var headingValue=hm.GetByID(id);//getbyid headingmanagerde tanımlı metod ve id ye göre degerleri dgetiriyor
            return View(headingValue);//burdada ekranda bir view göstercem lakin getbyid ile gelen bilgileri
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");

        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue=hm.GetByID(id);//önce id den gelen degeri getir
            headingvalue.HeadingStatus = false;
            hm.HeadingDelete(headingvalue);//sonra bu degeri sil
            return RedirectToAction("Index");




        }
    }
}

