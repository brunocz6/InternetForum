using InternetForum.DL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL
{
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Vrací repository pro tabulku Comments.
		/// </summary>
		ICommentRepository CommentRepository { get; }

		/// <summary>
		/// Vrací repository pro tabulku ForumThreads.
		/// </summary>
		IForumThreadRepository ForumThreadRepository { get; }

		/// <summary>
		/// Vrací repository pro tabulku Posts.
		/// </summary>
		IPostRepository PostRepository { get; }

		/// <summary>
		/// Vrací repository pro tabulku Users.
		/// </summary>
		IUserRepository UserRepository { get; }

		/// <summary>
		/// Vrací repository pro tabulku Ratings.
		/// </summary>
		IRatingRepository RatingRepository { get; }

		/// <summary>
		/// Uloží změny do databáze.
		/// </summary>
		int Save();
	}
}