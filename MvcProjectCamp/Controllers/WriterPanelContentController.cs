using MvcProjectCamp.BusinessLayer.Concrete;
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
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContent(string p, Heading heading)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(z => z.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var value = cm.TGetListByWriter(writerIdInfo);

            //admin lte de takvim sayfası başlıkların oluşturulma tarihi orada gözüksün:
            ViewBag.date = c.Contents.Where(z => z.HeadingId == heading.HeadingId).Select(y=>y.Heading.HeadingDate).FirstOrDefault();
            return View(value);

           
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headingId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {

            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            content.ContentDate = DateTime.Now;

            cm.TInsert(content);
            return RedirectToAction("MyContent");
        }
    }
}