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
			UserDetails userDetails = new UserDetails();
			userDetails.Email = model.Email;
			userDetails.Name = model.Name;
			userDetails.Password = model.Password;
			_context.UserDetails.Add(userDetails);
			_context.SaveChanges();
		} 
	}
}