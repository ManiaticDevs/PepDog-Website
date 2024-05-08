using PepDogWebsite.Services;
using PepDogWebsite.ViewModels;
using System.Runtime.Serialization;
using System.Web.Mvc;

namespace PepDogWebsite.Controllers {
    public class SecurityController : Controller {

		private ISecurityService _service = null;

		public SecurityController(ISecurityService service) {
			_service = service;
		}

		public ActionResult Login() {
            return View();
        }

		[HttpPost]
		public ActionResult Login(LoginViewModel model) {
			if(ModelState.IsValid) {
				if (_service.IsValidUser(model)) {
					return RedirectToAction("HomePage", "Home");
				} else {
					ModelState.AddModelError("", "Invalid username or password.");
				}
			}
			return View(model);
		}

		public ActionResult Register() {
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterViewModel model) {
			if(ModelState.IsValid) {
				if(_service.IsValidEmailAddress(model.Email)) {
					_service.SaveUserToDB(model);
					model.Message = "User registered successfully!";
					return RedirectToAction("HomePage", "Home");
				} else {
					ModelState.AddModelError("", "Invalid email!");
				}
			}
			return View(model);
		}
	}
}