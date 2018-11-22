using InternetForum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.Business.Interfaces
{
	public interface IForumThreadBusiness
	{
		void Delete(int id);
		void AddForumThread(ForumThreadDomainModel model);
		ForumThreadDomainModel GetForumThreadById(int id);
		ForumThreadDomainModel GetMainForumThread();
		IEnumerable<ForumThreadDomainModel> GetMostSubscribedForumThreads(int numberOfThreads);
		void AddSubscriber(string userId, int forumThreadId);
		void RemoveSubscriber(string userId, int forumThreadId);
	}
}