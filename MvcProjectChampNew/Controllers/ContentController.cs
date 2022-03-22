using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectChampNew.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        //önce solide aykırı sonrada uygun şekilde  arama yapcaz
      
        public ActionResult GetAllContent(string p)
        {

            var values = cm.GetList(p);
          
            
            return View(values);
        
        }
        public ActionResult ContentByHeading(int id)// belirli başlık id sine göre
            //listeleyebilmem için dışardan id parametresi göndermem gerekiyror int id
        {
            var contentvalues=cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}