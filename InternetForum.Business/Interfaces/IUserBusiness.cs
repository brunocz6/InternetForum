using InternetForum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.Business.Interfaces
{
	public interface IUserBusiness
	{
		UserDomainModel GetUserById(string id);
	}
}