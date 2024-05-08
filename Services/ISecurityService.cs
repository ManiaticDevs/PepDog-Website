using PepDogWebsite.Models;
using PepDogWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepDogWebsite.Services {
	public interface ISecurityService {
		void SaveUserToDB(RegisterViewModel model);
		bool IsValidUser(LoginViewModel model);
		bool IsValidEmailAddress(string email);
		List<Users> getUsersSet();
	}
}
