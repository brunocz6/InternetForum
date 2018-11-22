using InternetForum.DL.Entities;
using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Repositories
{
	internal class RatingRepository : Repository<Rating>, IRatingRepository
	{
		public RatingRepository(InternetForumDbContext dbContext) : base(dbContext)
		{
		}
	}
}