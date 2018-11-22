using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class ForumThreadRepository : Repository<ForumThread>, IForumThreadRepository
	{
		public ForumThreadRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
		}

		public IEnumerable<ForumThread> GetMostSubscribedForumThreads(int numberOfThreads)
		{
			return dbContext.ForumThreads
				.OrderByDescending(ft => ft.Subscribers.Count())
				.Take(numberOfThreads);
		}

		public ForumThread GetMainThread()
		{
			return dbContext.ForumThreads.FirstOrDefault();
		}

		public void AddSubscriber(string userId, int forumThreadId)
		{
			var subscription = new ForumThreadUser(userId, forumThreadId);


			this.dbContext.ForumThreadUsers.Add(subscription);
		}

		public void RemoveSubscriber(string userId, int forumThreadId)
		{
			var subscription = this.dbContext.ForumThreadUsers
				.Where(s => 
					s.ForumThreadId == forumThreadId && 
					s.UserId == userId
				);
		}
	}
}