using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
   
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.category = cm.TGetList().Count();
            ViewBag.software = hm.TGetSoftwareHeadingsCount();
            ViewBag.writer = wm.TGetWritersWithA();
            ViewBag.truefalse = cm.TCountTrueOrFalse();
            ViewBag.categorywithmosttitles = cm.TGetCategoryWithMostTitles();
            return View();
        }
    }
}