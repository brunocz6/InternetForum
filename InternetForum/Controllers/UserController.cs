using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InternetForum.DL;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InternetForum.Controllers
{
	public class UserController : BaseController
	{
		public UserController(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper) : base(unitOfWork, userManager, mapper)
		{
		}

		public IActionResult Index()
		{
			return RedirectToAction("Index", "Home");

		}

		public IActionResult Detail(string userId)
		{
			return RedirectToAction("Index", "Home");
		}
	}
}