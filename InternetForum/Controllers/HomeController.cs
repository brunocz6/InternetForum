using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InternetForum.DL;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using InternetForum.Business.Interfaces;
using InternetForum.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetForum.Controllers
{
	public class HomeController : BaseController
	{
		private readonly IPostBusiness postBusiness;
		private readonly IForumThreadBusiness forumThreadBusiness;

		public HomeController(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper,
			IPostBusiness postBusiness, IForumThreadBusiness forumThreadBusiness) : base(unitOfWork, userManager, mapper)
		{
			this.postBusiness = postBusiness;
			this.forumThreadBusiness = forumThreadBusiness;
		}

		// GET: /<controller>/
		public IActionResult Index(int page = 1)
		{
			var posts = this.postBusiness.GetMostRecentPosts(page, 20);
			var mostSubscribedThreads = this.forumThreadBusiness.GetMostSubscribedForumThreads(5);

			var postsViewModels = new List<PostViewModel>();
			var threadsViewModels = new List<ThreadInfoViewModel>();

			this.mapper.Map(posts, postsViewModels);
			this.mapper.Map(mostSubscribedThreads, threadsViewModels);

			var model = new HomeIndexViewModel()
			{
				Posts = postsViewModels,
				MostSubscribedThreads = threadsViewModels
			};

			return View(model);
		}
	}
}