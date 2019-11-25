using Praha20191113.Web.Models;
using Praha20191113.Web.Services;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Praha20191113.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ILogger Logger;
        protected readonly ApplicationDbContext Db;

        public BaseController(ILogger logger, ApplicationDbContext dbContext)
        {
            this.Logger = logger;
            this.Db = dbContext;
        }
        

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            string actionName = requestContext.RouteData.Values["action"].ToString();
            string controllerName = requestContext.RouteData.Values["controller"].ToString();

            Logger.Log($"Starting execution on {controllerName} controller : action = {actionName}");
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.Log($"Exception occurs {filterContext?.Exception?.Message}"); 
            base.OnException(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (Db != null)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}