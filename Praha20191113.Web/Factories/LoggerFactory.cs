using Praha20191113.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Praha20191113.Web.Factories
{
    public class LoggerFactory
    {
        public ILogger Create()
        {
            return new TraceLogger();
        }
    }
}