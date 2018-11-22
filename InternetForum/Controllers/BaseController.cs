using AutoMapper;
using InternetForum.DL;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IUnitOfWork unitOfWork;
		protected readonly UserManager<User> userManager;
		protected readonly IMapper mapper;

		protected IUnitOfWork UnitOfWork => unitOfWork;

		public BaseController(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.userManager = userManager;
			this.mapper = mapper;
		}

		protected User GetCurrentUser()
		{
			var userId = this.userManager.GetUserId(HttpContext.User);
			return this.userManager.FindByIdAsync(userId).Result;
		}
	}
}