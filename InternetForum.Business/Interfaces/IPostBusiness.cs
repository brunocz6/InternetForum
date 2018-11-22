using InternetForum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.Business.Interfaces
{
	public interface IPostBusiness
	{
		PostDomainModel GetPostById(int postId);

		IEnumerable<PostDomainModel> GetPostsByUserId(string userId);

		IEnumerable<PostDomainModel> GetUsersPost(UserDomainModel userModel);

		IEnumerable<PostDomainModel> GetMostRecentPosts(int page, int pageSize);

		void Add(PostDomainModel post);

		void Edit(PostDomainModel post);

		void Delete(PostDomainModel post);

		void Delete(int postId);
	}
}