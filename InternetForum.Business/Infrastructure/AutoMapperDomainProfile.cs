using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InternetForum.DL.Entities;
using InternetForum.Domain;

namespace InternetForum.Business.Infrastructure
{
	public class AutoMapperDomainProfile : Profile
	{
		public AutoMapperDomainProfile()
		{
			CreateMap<Post, PostDomainModel>();
			CreateMap<Rating, RatingDomainModel>();
			CreateMap<User, UserDomainModel>();
			CreateMap<Comment, CommentDomainModel>();
			CreateMap<ForumThread, ForumThreadDomainModel>();
		}
	}
}