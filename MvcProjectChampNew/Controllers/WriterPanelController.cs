using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjectChampNew.Controllers
{
    public class WriterPanelController : Controller

    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        Context c = new Context();





        [HttpGet]
        // GET: WriterPanel
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];

            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = wm.GetByIdD(id);

            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidatior writerValidatior = new WriterValidatior();
            ValidationResult results = writerValidatior.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
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
        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            // ViewBag.d = writeridinfo;

            var values = hm.GetListByWriter(writeridinfo);
            return View(values);

        }
        [HttpGet]
        public ActionResult NewHeading()
        {

            // ViewBag.m = deger;
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()


                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            //  ViewBag.d=writeridinfo;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");

        }
        [HttpGet]
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
            var headingValue = hm.GetByID(id);//getbyid headingmanagerde tanımlı metod ve id ye göre degerleri dgetiriyor
            return View(headingValue);//burdada ekranda bir view göstercem lakin getbyid ile gelen bilgileri
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");

        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetByID(id);//önce id den gelen degeri getir
            headingvalue.HeadingStatus = false;
            hm.HeadingDelete(headingvalue);//sonra bu degeri sil
            return RedirectToAction("MyHeading");




        }
        public ActionResult AllHeading(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p, 4);
            return View(headings);

        }
    }
}

//< customErrors mode = "On" >

//         < error statusCode = "404" redirect = "/ErrorPage/Page404/" />





//        </ customErrors >