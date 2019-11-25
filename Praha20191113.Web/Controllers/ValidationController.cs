using Praha20191113.Web.Models;
using System.Web.Mvc;

namespace Praha20191113.Web.Controllers
{
    public class ValidationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View(new DataAnnotationValidationViewModel());
        }

        [HttpPost]
        public ActionResult Create(DataAnnotationValidationViewModel modelToCreate)
        {
            if (modelToCreate.Email.Contains("sex"))
            {
                ModelState.AddModelError(nameof(DataAnnotationValidationViewModel.Email), "Cannot contain sex in email");
            }
            if (!ModelState.IsValid)
            {
                return View(modelToCreate);
            }

            return Json(modelToCreate);
        }
    }
}