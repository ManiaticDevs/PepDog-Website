using PepDogWebsite.Models;
using PepDogWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PepDogWebsite.Services {
	public class SecurityService : ISecurityService {
		private PepDogServerEntities _context = null;

		public SecurityService() {
			_context = new PepDogServerEntities();
		}

		public void SaveUserToDB(RegisterViewModel model) {
			Users userDetails = new Users();
			userDetails.Email = model.Email;
			userDetails.Name = model.Name;
			userDetails.Password = model.Password;
			_context.Users.Add(userDetails);
			_context.SaveChanges();
		}

		public bool IsValidUser(LoginViewModel model) {
			Users user = null;
			user = _context.Users.SingleOrDefault(c => c.Email.Equals(model.Username) && c.Password.Equals(model.Password));
			return user != null;
		}

		public bool IsValidEmailAddress(string email) {
			try {
				var emailChecked = new System.Net.Mail.MailAddress(email);
				return true;
			} catch {
				return false;
			}
		}
	}
}