using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.Domain
{
	public class PostDomainModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID příspěvku.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje datum přidání příspěvku.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje autora příspěvku.
		/// </summary>
		public UserDomainModel Author { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje hodnocení příspěvku.
		/// </summary>
		public IEnumerable<RatingDomainModel> Rating { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kterého vlákna je příspěvek součástí.
		/// </summary>
		public ForumThreadDomainModel ForumThread { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci komentářů, které spadají pod tento příspěvek.
		/// </summary>
		public IEnumerable<CommentDomainModel> Comments { get; set; }
	}
}