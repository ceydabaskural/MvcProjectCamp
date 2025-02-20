using FluentValidation.Results;
using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.BusinessLayer.ValidationRules;
using MvcProjectCamp.DataAccessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {

            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(z => z.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = wm.TGetById(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                wm.TUpdate(writer);
                return RedirectToAction(nameof(MyHeading));
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var value = hm.TGetListByWriter(writerIdInfo);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryList = (from x in cm.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.d = writerIdInfo;
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.HeadingStatus = true;
            hm.TInsert(heading);
            return RedirectToAction(nameof(MyHeading));
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

            var value = hm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            hm.TUpdate(heading);
            return RedirectToAction(nameof(MyHeading));
        }
        public ActionResult DeleteHeading(int id)
        {
            var value = hm.TGetById(id);
            value.HeadingStatus = false;
            hm.TDelete(value);
            return RedirectToAction(nameof(MyHeading));
        }
    }
}