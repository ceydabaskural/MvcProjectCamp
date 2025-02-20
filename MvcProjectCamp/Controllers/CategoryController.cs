using MvcProjectCamp.BusinessLayer.Concrete;
using MvcProjectCamp.BusinessLayer.ValidationRules;
using MvcProjectCamp.DataAccessLayer;
using MvcProjectCamp.EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;
using MvcProjectCamp.DataAccessLayer.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
       CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles = "B")] //sadece login olan kullanıcılar erişebilecek
        public ActionResult Index()
        {
            var category = cm.TGetList();
            return View(category);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                cm.TInsert(category);
                TempData["SuccessMessage"] = "Category added successfully!";
                TempData.Keep("SuccessMessage"); // TempData'nın yönlendirme sonrası korunmasını sağlar
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = cm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cm.TUpdate(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
