using ActionParameterAlias;
using PepDogWebsite.Models;
using PepDogWebsite.Services;
using PepDogWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PepDogWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ISecurityService _service = null;

        public HomeController(ISecurityService service) {
            _service = service;
        }

        public ActionResult User(int ID) {
            Users user = _service.GetUserFromID(ID);
            if(user != null) {
				return View(_service.GetUserFromID(ID));
			} else {
                return RedirectToAction("Users", "Home");
            }
			
		}

		public ActionResult Users() {
            return View(_service.GetUsersSet());
        }

        // GET: Home
        public ActionResult HomePage() {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(LoginViewModel model) {
			if (ModelState.IsValid) {
				if (_service.IsValidUser(model)) {
					this.Session.Add("username", model.Username);
					FormsAuthentication.SetAuthCookie(model.Username, false);
					return RedirectToAction("HomePage", "Home");
				} else {
					ModelState.AddModelError("", "Invalid username or password.");
				}
			}
			return View();
        }
    }
}