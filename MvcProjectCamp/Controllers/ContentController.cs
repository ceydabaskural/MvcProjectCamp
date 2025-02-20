using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = cm.TGetList(p);

            if (p == null)
            {
                return View(cm.TGetList());
            }
            else
            {
                return View(values);
            }
        }
        

        public ActionResult ViewContentByHeading(int id)
        {
            var values = cm.TGetListByHeadingId(id);
            return View(values);
        }
    }
}