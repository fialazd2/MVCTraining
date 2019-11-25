using System.Web.Mvc;

namespace Praha20191113.Web.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            var model = "Hello World22!!";
            return View(model: model);
        }
    }
}