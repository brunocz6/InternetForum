using InternetForum.Business.Interfaces;
using InternetForum.DL;
using System;
using System.Collections.Generic;
using System.Text;
using InternetForum.Domain;
using AutoMapper;

namespace InternetForum.Business
{
	public class UserBusiness : BusinessBase, IUserBusiness
	{
		public UserBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

		public UserDomainModel GetUserById(string id)
		{
			var userEntity = this.unitOfWork.UserRepository.GetById(id);
			var user = new UserDomainModel();
			Mapper.Map(userEntity, user);

			return user;
		}
	}
}