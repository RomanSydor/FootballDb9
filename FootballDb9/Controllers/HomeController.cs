using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Web.Mvc;

namespace FootballDb9.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}