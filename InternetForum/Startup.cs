using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using InternetForum.DL;
using Microsoft.AspNetCore.Identity;
using InternetForum.DL.Entities;
using InternetForum.Services;
using AutoMapper;
using InternetForum.Infrastructure;
using InternetForum.Business.Interfaces;
using InternetForum.Business;

namespace InternetForum
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<InternetForumDbContext>(options =>
				options
					.UseLazyLoadingProxies()
					.UseSqlServer("Server=.\\SQLEXPRESS;Database=InternetForum;Trusted_Connection=true")
			);

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<InternetForumDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication()
				.AddFacebook(facebookOptions =>
				{
					facebookOptions.AppId = "1955015674620090";
					facebookOptions.AppSecret = "0354fd7b50e4a85583e4016b5b065418";
				});

			services.Configure<IdentityOptions>(options =>
			{
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;
			});

			services.ConfigureApplicationCookie(options =>
			{
				// Cookie settings
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

				options.LoginPath = "/Account/Login";
				options.AccessDeniedPath = "/Account/AccessDenied";
				options.SlidingExpiration = true;
			});

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			// Business objekty
			services.AddScoped<IPostBusiness, PostBusiness>();
			services.AddScoped<IUserBusiness, UserBusiness>();
			services.AddScoped<IForumThreadBusiness, ForumThreadBusiness>();
			services.AddScoped<ICommentBusiness, CommentBusiness>();

			// AutoMapper
			services.AddAutoMapper(a => a.AddProfile<AutoMapperWebProfile>());

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
		{

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}