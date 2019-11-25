using Ninject.Modules;
using Ninject.Web.Common;
using Praha20191113.Web.Models;
using Praha20191113.Web.Services;
using System;

namespace Praha20191113.Web.Modules
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<TraceLogger>();
            Bind<ApplicationDbContext>().ToSelf().InRequestScope();

        }
    }
}