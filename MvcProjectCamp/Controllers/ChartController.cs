using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryCount = 8,
                CategoryName = "Software",
            });
            ct.Add(new CategoryClass()
            {
                CategoryCount = 4,
                CategoryName = "Travel",
            });
            ct.Add(new CategoryClass()
            {
                CategoryCount = 7,
                CategoryName = "Technology",
            });
            ct.Add(new CategoryClass()
            {
                CategoryCount = 1,
                CategoryName = "Environment",
            });
            return ct;
        }
    }
}