using InternetForum.Business.Interfaces;
using System;
using InternetForum.Domain;
using System.Collections.Generic;
using InternetForum.DL;
using InternetForum.DL.Entities;
using System.Linq;
using AutoMapper;

namespace InternetForum.Business
{
	public class PostBusiness : BusinessBase, IPostBusiness
	{
		public PostBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>
		/// Přidá do databáze nový příspěvek.
		/// </summary>
		/// <param name="postModel">Domain model příspěvku</param>
		public void Add(PostDomainModel postModel)
		{
			var defaultThread = this.unitOfWork.ForumThreadRepository.FirstOrDefault();

			var user = this.unitOfWork.UserRepository.GetById(postModel.Author.Id);

			var ratings = new List<Rating>();
			Mapper.Map(postModel.Rating, ratings);

			var post = new Post()
			{
				Author = user,
				ForumThread = defaultThread,
				Ratings = ratings,
				CreatedAt = postModel.CreatedAt,
				Title = postModel.Title,
				Body = postModel.Body
			};

			this.unitOfWork.PostRepository.Add(post);
			this.unitOfWork.Save();
		}

		/// <summary>
		/// Smaže příspěvek s daným ID.
		/// </summary>
		/// <param name="postId">Id příspěvku ke smazání</param>
		public void Delete(int postId)
		{
			var post = this.unitOfWork.PostRepository.GetById(postId);
			this.unitOfWork.PostRepository.Remove(post);
			this.unitOfWork.Save();
		}

		/// <summary>
		/// Smaže daný příspěvek.
		/// </summary>
		/// <param name="postModel">Příspěvek ke smazání</param>
		public void Delete(PostDomainModel postModel)
		{
			Delete(postModel.Id);
		}

		/// <summary>
		/// Vloží do již existujícího příspěvku upravená data z domain modelu.
		/// </summary>
		/// <param name="postModel">Domain model příspěvku</param>
		public void Edit(PostDomainModel postModel)
		{
			var post = this.unitOfWork.PostRepository.GetById(postModel.Id);

			post.Title = postModel.Title;
			post.Body = postModel.Body;

			this.unitOfWork.PostRepository.Update(post);
			this.unitOfWork.Save();
		}

		public IEnumerable<PostDomainModel> GetMostRecentPosts(int page, int pageSize)
		{
			var postsEntities = this.unitOfWork.PostRepository.GetMostRecentPosts(page, pageSize);
			var posts = new List<PostDomainModel>();
			Mapper.Map(postsEntities, posts);

			return posts;
		}

		/// <summary>
		/// Vrací příspěvek s daným ID.
		/// </summary>
		/// <param name="postId">Id příspěvku</param>
		/// <returns>Model příspěvku jako <see cref="PostDomainModel"/></returns>
		public PostDomainModel GetPostById(int postId)
		{
			var postEntity = this.unitOfWork.PostRepository.GetById(postId);

			if (postEntity == null)
				return null;

			var post = new PostDomainModel();

			Mapper.Map(postEntity, post);

			return post;
		}

		/// <summary>
		/// Vrací příspěvky daného uživatele.
		/// </summary>
		/// <param name="userId">Id uživatele</param>
		/// <returns>Kolekci příspěvků uživatele jako <see cref="IEnumerable{PostDomainModel}"/></returns>
		public IEnumerable<PostDomainModel> GetPostsByUserId(string userId)
		{
			var postEntities = this.unitOfWork.PostRepository.GetUsersPosts(userId, 1, 20);

			var posts = new List<PostDomainModel>();

			Mapper.Map(postEntities, posts);

			return posts;
		}

		/// <summary>
		/// Vrací příspěvky daného uživatele.
		/// </summary>
		/// <param name="userModel">Domain model uživatele.</param>
		/// <returns>Kolekci příspěvků uživatele jako <see cref="IEnumerable{PostDomainModel}"/></returns>
		public IEnumerable<PostDomainModel> GetUsersPost(UserDomainModel userModel)
		{
			return GetPostsByUserId(userModel.Id);
		}
	}
}