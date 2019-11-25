using Praha20191113.Web.Models;
using System;

namespace Praha20191113.Web.Services
{
    public class DatabaseLogger : ILogger
    {
        private ApplicationDbContext dbContext;

        public DatabaseLogger(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Log(string message)
        {
            dbContext.Log.Add(new Log() { Message = message, Time = DateTime.Now });
            dbContext.SaveChanges();
        }
    }
}