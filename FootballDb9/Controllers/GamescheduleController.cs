using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace FootballDb9.Controllers
{
	public class GamescheduleController:Controller
	{
	   private FootballDb9.Models.lab2dbEntities db = new FootballDb9.Models.lab2dbEntities();
	   
	     //
        // GET: /gameschedule/

        public ActionResult Index()
        {
            return View(db.gameschedule.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}
