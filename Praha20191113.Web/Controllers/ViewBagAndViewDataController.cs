using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Praha20191113.Web.Controllers
{
    public class ViewBagAndViewDataController : Controller
    {
        public ActionResult ViewBagAction()
        {
            ViewBag.ViewBagCaption = "Caption from ViewBag";
            return View();
        }

        public ActionResult ViewDataAction()
        {
            ViewData["ViewDataCaption"] = "Caption from ViewData";
            return View();
        }

    }
}