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

        // GET: Security
        public ActionResult Logon() {
            return View();
        }

		public ActionResult Register() {
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterViewModel model) {
			if(ModelState.IsValid) {
				_service.SaveUserToDB(model);
				model.Message = "User registered successfully!";
				return View();
			}
			
			return View(model);
		}
	}
}