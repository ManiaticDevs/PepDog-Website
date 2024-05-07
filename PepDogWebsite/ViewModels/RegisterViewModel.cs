using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PepDogWebsite.ViewModels {
	public class RegisterViewModel {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Message { get; set; }

	}
}