using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InternetForum.DL
{
	public class InternetForumDbContextFactory : IDesignTimeDbContextFactory<InternetForumDbContext>
	{
		public InternetForumDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<InternetForumDbContext>();
			builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=InternetForum;Trusted_Connection=true",
				optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(InternetForumDbContext).GetTypeInfo().Assembly.GetName().Name));

			return new InternetForumDbContext(builder.Options);
		}
	}
}