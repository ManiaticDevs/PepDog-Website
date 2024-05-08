using PepDogWebsite.Services;
using PepDogWebsite.ViewModels;
using System;
using System.Runtime.Serialization;
using System.Web.Mvc;
using System.Web.Security;

namespace PepDogWebsite.Controllers {
    public class SecurityController : Controller {

		private ISecurityService _service = null;

		public SecurityController(ISecurityService service) {
			_service = service;
		}

		public ActionResult Login() {
			if (this.Session != null && this.Session["username"] != null) {
				return RedirectToAction("HomePage", "Home");
			}
			return View();
        }

		[HttpPost]
		public ActionResult Login(LoginViewModel model) {
			if(ModelState.IsValid) {
				if (_service.IsValidUser(model)) {
					this.Session.Add("username", model.Username);
					FormsAuthentication.SetAuthCookie(model.Username, false);
					return RedirectToAction("HomePage", "Home");
				} else {
					ModelState.AddModelError("", "Invalid username or password.");
				}
			}
			return View(model);
		}

		public ActionResult Register() {
			if (this.Session != null && this.Session["username"] != null) {
				return RedirectToAction("HomePage", "Home");
			}
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterViewModel model) {
			if(ModelState.IsValid) {
				if(_service.IsValidEmailAddress(model.Email)) {
					model.joined = DateTime.Now;
					_service.SaveUserToDB(model);
					model.Message = "User registered successfully!";
					this.Session.Add("username", model.Name);
					return RedirectToAction("HomePage", "Home");
				} else {
					ModelState.AddModelError("", "Invalid email!");
				}
			}
			return View(model);
		}

		public ActionResult Logout() {
			FormsAuthentication.SignOut();
			this.Session["username"] = null;
			return RedirectToAction("HomePage","Home");
		}
	}
}