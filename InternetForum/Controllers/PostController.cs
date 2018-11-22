using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetForum.DL;
using Microsoft.AspNetCore.Mvc;
using InternetForum.Models;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using InternetForum.Domain;
using InternetForum.Business.Interfaces;

namespace InternetForum.Controllers
{
	public class PostController : BaseController
	{
		private readonly IPostBusiness postBusiness;
		private readonly IForumThreadBusiness forumThreadBusiness;
		private readonly IUserBusiness userBusiness;

		public PostController(IUnitOfWork unitOfWork, UserManager<User> userManager,AutoMapper.IMapper mapper,
			IPostBusiness postBusiness, IUserBusiness userBusiness, IForumThreadBusiness forumThreadBusiness) 
			: base(unitOfWork, userManager, mapper)
		{
			this.postBusiness = postBusiness;
			this.forumThreadBusiness = forumThreadBusiness;
			this.userBusiness = userBusiness;
		}


		[Authorize]
		public IActionResult MyPosts(int page = 1)
		{
			var posts = this.postBusiness.GetPostsByUserId(GetCurrentUser().Id);

			var model = new List<PostViewModel>();

			this.mapper.Map(posts, model);

			return View(model);
		}


		[Authorize]
		public IActionResult Create()
		{
			var model = new CreatePostViewModel();

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create(CreatePostViewModel model)
		{
			var post = new PostDomainModel();
			this.mapper.Map(model, post);

			post.Author = this.userBusiness.GetUserById(GetCurrentUser().Id);
			post.ForumThread = this.forumThreadBusiness.GetMainForumThread();
			post.CreatedAt = DateTime.Now;

			this.postBusiness.Add(post);

			return RedirectToAction("Index", "Home", null);
		}

		[Authorize]
		public IActionResult Edit(int id)
		{
			var post = this.postBusiness.GetPostById(id);
			var model = new EditPostViewModel();
			this.mapper.Map(post, model);

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Edit(EditPostViewModel model)
		{
			var post = new PostDomainModel();
			this.mapper.Map(model, post);
			this.postBusiness.Edit(post);

			return RedirectToAction("Index", "Home", null);
		}

		public IActionResult Detail(int id)
		{
			var post = this.postBusiness.GetPostById(id);

			if (post == null)
				return NotFound();

			var model = new PostViewModel();

			this.mapper.Map(post, model);

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public IActionResult Delete(int id)
		{
			this.postBusiness.Delete(id);

			return RedirectToAction(nameof(MyPosts));
		}
	}
}