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
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValue = adm.TGetList();
            return View(adminValue);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            // Adminleri alıyoruz
            var admins = adm.TGetList();

            // Her rolden bir admin seçmek için gruplama yapıyoruz
            var adminsByRole = admins
                .GroupBy(a => a.AdminRole)  // Adminleri role göre grupla
                .Select(g => g.First())  // Her rolden ilk admini al
                .ToList();

            // Seçilen adminleri SelectListItem listesine dönüştürme
            List<SelectListItem> roles = adminsByRole
                .Select(x => new SelectListItem
                {
                    Text = x.AdminRole,
                    Value = x.AdminId.ToString()
                }).ToList();

            ViewBag.Roles = roles;

            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.TInsert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var value = adm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.TUpdate(p);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteAdmin(int id)
        {
            var result = adm.TGetById(id);
            adm.TDelete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Status(int id)
        {
            var admin = adm.TGetById(id);

            if (admin != null)
            {
                admin.IsActive = !admin.IsActive;  // Mevcut durumu tersine çevirir
                adm.TUpdate(admin);  // Güncellenmiş içeriği kaydeder
            }
            return RedirectToAction("Index");
        }
    }
}