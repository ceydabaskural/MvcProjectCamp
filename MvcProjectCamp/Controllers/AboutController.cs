using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using MvcProjectCamp.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var value = abm.TGetList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            abm.TInsert(about);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = abm.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            abm.TUpdate(about);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = abm.TGetById(id);
            abm.TDelete(value);
            return RedirectToAction(nameof(Index));
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Status(int id)
        {
            var about = abm.TGetById(id);

            if (about != null)
            {
                about.IsActive = !about.IsActive;  // Mevcut durumu tersine çevirir
                abm.TUpdate(about);  // Güncellenmiş içeriği kaydeder
            }
            return RedirectToAction("Index");
        }
    }
}