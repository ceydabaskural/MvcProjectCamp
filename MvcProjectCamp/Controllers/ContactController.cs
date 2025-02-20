using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.BusinessLayer.ValidationRules;
using MvcProjectCamp.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var value = cm.TGetList();
            return View(value);
        }

        public ActionResult GetContactDetails(int id)
        {
            var value = cm.TGetById(id);
            return View(value);

        }
        public PartialViewResult MessageSideBar()
        {
            return PartialView();
        }
    }
}