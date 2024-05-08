using PepDogWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PepDogWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ISecurityService _service = null;

        public HomeController(ISecurityService service) {
            _service = service;
        }

        // GET: Home
        public ActionResult HomePage()
        {
            return View();
        }
    }
}