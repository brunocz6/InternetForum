using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InternetForum.DL;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InternetForum.Models;
using InternetForum.Domain;
using InternetForum.Business.Interfaces;

namespace InternetForum.Controllers
{
	public class CommentController : BaseController
	{
		private readonly IUserBusiness userBusiness;
		private readonly ICommentBusiness commentBusiness;

		public CommentController(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper,
			IUserBusiness userBusiness, ICommentBusiness commentBusiness) : base(unitOfWork, userManager, mapper)
		{
			this.userBusiness = userBusiness;
			this.commentBusiness = commentBusiness;
		}

		[Authorize]
		public IActionResult Add(CreateCommentViewModel comment)
		{
			var c = new CommentDomainModel();
			this.mapper.Map(comment, c);
			c.Author = this.userBusiness.GetUserById(GetCurrentUser().Id);

			this.commentBusiness.AddCommentToPost(c, comment.PostId);

			return RedirectToAction("Detail", "Post", new { id = comment.PostId });
		}

		[Authorize]
		public IActionResult Delete(int commentId)
		{
			var userId = GetCurrentUser().Id;

			this.commentBusiness.Delete(commentId, userId);

			return Content("Ok");
		}
	}
}