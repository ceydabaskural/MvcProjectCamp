using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var value = hm.TGetHeadingList();
            return View(value);
        } 
        public ActionResult HeadingReport()
        {
            var value = hm.TGetHeadingList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateHeading()
        {
            List<SelectListItem> categoryList = (from x in cm.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;

            List<SelectListItem> authorList = (from x in wm.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName + " " + x.WriterSurname,
                                                   Value = x.WriterId.ToString()
                                               }).ToList();
            ViewBag.author = authorList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.TInsert(heading);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categoryList = (from x in cm.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;

            List<SelectListItem> authorList = (from x in wm.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName + " " + x.WriterSurname,
                                                   Value = x.WriterId.ToString()
                                               }).ToList();
            ViewBag.author = authorList;

            var value = hm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            hm.TUpdate(heading);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteHeading(int id)
        {
            var value = hm.TGetById(id);
            value.HeadingStatus = false;
            hm.TDelete(value);
            return RedirectToAction(nameof(Index));
        }
    }
}