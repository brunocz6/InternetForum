using AutoMapper;
using InternetForum.Business.Interfaces;
using InternetForum.DL;
using InternetForum.DL.Entities;
using InternetForum.Domain;
using InternetForum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InternetForum.Controllers
{
	public class ForumThreadController : BaseController
	{
		private readonly IForumThreadBusiness forumThreadBusiness;

		public ForumThreadController(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper, IForumThreadBusiness forumThreadBusiness) : base(unitOfWork, userManager, mapper)
		{
			this.forumThreadBusiness = forumThreadBusiness;
		}

		public IActionResult List()
		{
			var forumThreads = this.forumThreadBusiness.GetMostSubscribedForumThreads(10);

			var model = new List<ForumThreadDomainModel>();
			this.mapper.Map(forumThreads, model);

			return View(model);
		}

		public IActionResult Create()
		{
			var model = new CreateForumThreadViewModel();

			return View(model);
		}

		[HttpPost]
		public IActionResult Create(CreateForumThreadViewModel model)
		{
			var forumThread = new ForumThreadDomainModel();
			this.mapper.Map(model, forumThread);

			this.forumThreadBusiness.AddForumThread(forumThread);

			return RedirectToAction(nameof(List));
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			this.forumThreadBusiness.Delete(id);
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public IActionResult Subscribe(int forumThreadId)
		{
			var userId = GetCurrentUser().Id;
			this.forumThreadBusiness.AddSubscriber(userId, forumThreadId);

			return RedirectToAction(nameof(List));
		}

		[HttpPost]
		public IActionResult Unsubscribe(int forumThreadId)
		{
			var userId = GetCurrentUser().Id;
			this.forumThreadBusiness.RemoveSubscriber(userId, forumThreadId);

			return RedirectToAction(nameof(List));
		}
	}
}