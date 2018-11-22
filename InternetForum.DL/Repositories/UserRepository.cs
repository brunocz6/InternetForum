using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
		}
	}
}