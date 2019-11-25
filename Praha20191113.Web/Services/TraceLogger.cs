using System;
using System.Diagnostics;

namespace Praha20191113.Web.Services
{
    public class TraceLogger : ILogger
    {
        public void Log(string message)
        {
            Trace.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}