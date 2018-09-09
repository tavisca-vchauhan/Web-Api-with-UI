using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Design.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Activity()
        {
            return View();
        }

        public ActionResult Car()
        {
            return View();
        }

        public ActionResult Hotel()
        {
            return View();
        }

        public ActionResult Air()
        {
            return View();
        }
    }
}