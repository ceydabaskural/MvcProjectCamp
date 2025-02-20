using FluentValidation.Results;
using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.BusinessLayer.ValidationRules;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var value = wm.TGetList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWriter(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                wm.TInsert(writer);
                return RedirectToAction("Index");
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

        public ActionResult DeleteWriter(int id)
        {
            var value = wm.TGetById(id);
            wm.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var value = wm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                wm.TUpdate(writer);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}