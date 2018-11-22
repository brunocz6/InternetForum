using InternetForum.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.Business.Interfaces
{
	public interface ICommentBusiness
	{
		/// <summary>
		/// Přidá k příspěvku nový komentář.
		/// </summary>
		/// <param name="comment">Domain model komentáře, který mimo jiné obsahuje i informace o autorovi.</param>
		void AddCommentToPost(CommentDomainModel comment, int postId);
		
		/// <summary>
		/// Smaže komentář, pokud se o jeho smazání pokusil jeho autor a nikdo jiný.
		/// </summary>
		/// <param name="commentId">Id komentáře určeného ke smazání.</param>
		/// <param name="userId">Id uživatele, který chce komentář smazat.</param>
		void Delete(int commentId, string userId);
	}
}