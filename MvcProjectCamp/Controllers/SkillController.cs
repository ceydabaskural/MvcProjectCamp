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
    public class SkillController : Controller
    {
        SkillManager _skillManager = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            Random random = new Random();

            // Veritabanından Skill tablosundaki tüm verileri çekiyoruz
            var skills = _skillManager.TGetList();

            // Rastgele yüzdelik değerleri bir sözlük (Dictionary) içinde tutuyoruz
            Dictionary<int, double> skillPercentages = new Dictionary<int, double>();

            foreach (var skill in skills)
            {
                skillPercentages[skill.SkillId] = Math.Round(random.NextDouble() * 100, 2); // 0-100 arası 2 ondalıklı rastgele sayı
            }

            ViewBag.SkillPercentages = skillPercentages; // View'e taşıyoruz
            return View(skills);
        }
    }
}