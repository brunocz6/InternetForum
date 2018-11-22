using InternetForum.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using InternetForum.Domain;
using InternetForum.DL;
using InternetForum.DL.Entities;

namespace InternetForum.Business
{
	public class CommentBusiness : BusinessBase, ICommentBusiness
	{
		public CommentBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public void AddCommentToPost(CommentDomainModel comment, int postId)
		{
			var post = this.unitOfWork.PostRepository.GetById(postId);
			var author = this.unitOfWork.UserRepository.GetById(comment.Author.Id);

			var commentEntity = new Comment()
			{
				Post = post,
				Author = author,
				Body = comment.Body
			};

			this.unitOfWork.CommentRepository.Add(commentEntity);

			this.unitOfWork.Save();
		}

		public void Delete(int commentId, string userId)
		{
			var comment = this.unitOfWork.CommentRepository.GetById(commentId);
			if (comment.Post.Author.Id == userId)
			{
				this.unitOfWork.CommentRepository.Remove(comment);
				this.unitOfWork.Save();
			}
		}
	}
}