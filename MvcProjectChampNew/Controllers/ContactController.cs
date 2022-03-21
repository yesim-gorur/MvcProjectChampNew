using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectChampNew.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager( new EFContactDal());
        ContactValidator cv = new ContactValidator();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();//getlist metodumla contact tablosundaki tüm degerleri bana getir bunu da contactvalues de tut
            return View(contactvalues);//sonra sayfayı döndür ama nasıl contact values içinde getir.
        }
        public ActionResult GetContactDetails(int id)//gönderdiğim id ye göre degeri getirecegiz
        {
            var contactvalues = cm.GetById(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {//contact sayfasındaki sagdaki kısmı partial vie yapıyoruz

            return PartialView();

        }
    }
}