using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SampleWeb.Controllers
{
    public class HomeController : Controller
    {
        const string connectionString = "Server=.;Database=efcachetest;Trusted_Connection=SSPI;Application Name=efcachetest";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deadlock()
        {
            var db = new SampleDbContext(connectionString);
            var user = db.Users.FindAsync(1).Result;

            return Content("done: " + user?.Name);
        }

        public async Task<ActionResult> NoDeadlock()
        {
            var db = new SampleDbContext(connectionString);
            await Task.Delay(100).ConfigureAwait(false);
            // because of the configureAwait, the code below is not running in the asp.net synchronization context
            // so it does not deadlock. 
            var user = db.Users.FindAsync(1).Result;

            return Content("done: " + user?.Name);
        }

    }
}