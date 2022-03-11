using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageValidatior = new MessageValidator();
        [Authorize]
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
                
            var messagelist = mm.GetListSendbox();
            return View(messagelist);

        }
        public ActionResult GetInBoxMessageDetails(int id)//gönderdiğim id ye göre degeri getirecegiz
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult SendBoxMessageDetails(int id)//gönderdiğim id ye göre degeri getirecegiz
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidatior.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(p);
                return RedirectToAction("Sendbox");
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
    }
}