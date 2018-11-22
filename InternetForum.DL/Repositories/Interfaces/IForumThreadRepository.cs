using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories.Interfaces
{
	public interface IForumThreadRepository : IRepository<ForumThread>
	{
		ForumThread GetMainThread();

		IEnumerable<ForumThread> GetMostSubscribedForumThreads(int numberOfThreads);
		void AddSubscriber(string userId, int forumThreadId);
		void RemoveSubscriber(string userId, int forumThreadId);
	}
}