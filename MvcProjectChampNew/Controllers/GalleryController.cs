using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectChampNew.Controllers
{
    public class GalleryController : Controller
    {

        ImageFileManager ifm = new ImageFileManager(new EFImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files=ifm.GetList();
            return View(files);
        }
    }
}