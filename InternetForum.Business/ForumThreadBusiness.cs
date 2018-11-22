using InternetForum.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using InternetForum.Domain;
using InternetForum.DL;
using AutoMapper;
using InternetForum.DL.Entities;

namespace InternetForum.Business
{
	public class ForumThreadBusiness : BusinessBase, IForumThreadBusiness
	{

		public ForumThreadBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public ForumThreadDomainModel GetForumThreadById(int id)
		{
			var forumThread = new ForumThreadDomainModel();
			var forumThreadEntity = this.unitOfWork.ForumThreadRepository.GetById(id);
			Mapper.Map(forumThreadEntity, forumThread);

			return forumThread;
		}

		public ForumThreadDomainModel GetMainForumThread()
		{
			var forumThread = new ForumThreadDomainModel();
			var forumThreadEntity = this.unitOfWork.ForumThreadRepository.GetMainThread();
			Mapper.Map(forumThreadEntity, forumThread);

			return forumThread;
		}

		public IEnumerable<ForumThreadDomainModel> GetMostSubscribedForumThreads(int numberOfThreads)
		{
			var forumThreadsEntities = this.unitOfWork.ForumThreadRepository.GetMostSubscribedForumThreads(numberOfThreads);
			var forumThreads = new List<ForumThreadDomainModel>();

			Mapper.Map(forumThreadsEntities, forumThreads);

			return forumThreads;
		}

		public void AddForumThread(ForumThreadDomainModel model)
		{
			var forumThread = new ForumThread()
			{
				Name = model.Name,
				Description = model.Description
			};

			this.unitOfWork.ForumThreadRepository.Add(forumThread);
			this.unitOfWork.Save();
		}

		public void Delete(int id)
		{
			var forumThread = this.unitOfWork.ForumThreadRepository.GetById(id);

			this.unitOfWork.ForumThreadRepository.Remove(forumThread);
			this.unitOfWork.Save();
		}

		public void AddSubscriber(string userId, int forumThreadId)
		{
			this.unitOfWork.ForumThreadRepository.AddSubscriber(userId, forumThreadId);
			this.unitOfWork.Save();
		}

		public void RemoveSubscriber(string userId, int forumThreadId)
		{
			this.unitOfWork.ForumThreadRepository.RemoveSubscriber(userId, forumThreadId);
			this.unitOfWork.Save();
		}
	}
}