using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InternetForum.Domain;
using InternetForum.Models;

namespace InternetForum.Infrastructure
{
	public class AutoMapperWebProfile : Profile
	{
		public AutoMapperWebProfile()
		{
			// Mapování pro modely příspěvků
			CreateMap<PostDomainModel, CreatePostViewModel>();
			CreateMap<PostDomainModel, PostViewModel>();
			CreateMap<PostDomainModel, EditPostViewModel>();
			CreateMap<CreatePostViewModel, PostDomainModel>();
			CreateMap<EditPostViewModel, PostDomainModel>();

			// Mapování pro modely uživatele
			CreateMap<UserDomainModel, UserViewModel>();
			CreateMap<UserViewModel, UserDomainModel>();

			// Mapování pro vlákna příspěvků
			CreateMap<ForumThreadDomainModel, CreateForumThreadViewModel>();
			CreateMap<ForumThreadDomainModel, ForumThreadViewModel>();
			CreateMap<CreateForumThreadViewModel, ForumThreadDomainModel>();
			CreateMap<ForumThreadViewModel, ForumThreadDomainModel>();


			// Mapování pro model hodnocení
			CreateMap<RatingDomainModel, RatingViewModel>();
			CreateMap<RatingViewModel, RatingDomainModel>();

			// Mapování pro modely komentářů
			CreateMap<CommentDomainModel, CommentViewModel>();
			CreateMap<CommentViewModel, CommentDomainModel>();
			CreateMap<CreateCommentViewModel, CommentDomainModel>();

			// Mapování pro model uživatelů
			CreateMap<UserDomainModel, UserViewModel>();
		}
	}
}