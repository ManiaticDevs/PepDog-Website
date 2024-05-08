using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PepDogWebsite.ViewModels {
	public class RegisterViewModel {
		[Required(ErrorMessage ="Name is required!")]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Username was too short (3 min) or too long (20 max)!")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Email was not valid!")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is required!")]
		[StringLength(20,MinimumLength = 7, ErrorMessage = "Password was too short (7 min) or too long (20 max)!")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Password needs to be confirmed!")]
		[StringLength(20, MinimumLength = 7, ErrorMessage = "Password was not equal!")]
		[Compare("Password", ErrorMessage = "Password was not equal!")]
		public string ConfirmPassword { get; set; }
		public DateTime joined { get; set; }
		public string Message { get; set; }

	}
}