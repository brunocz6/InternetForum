using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class PostViewModel
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
		/// Vrací nebo nastavuje autora příspěvku.
		/// </summary>
		public UserViewModel Author { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje datum přidání příspěvku.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje hodnocení příspěvku.
		/// </summary>
		public RatingViewModel Rating { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje komentáře příspěvku.
		/// </summary>
		public IEnumerable<CommentViewModel> Comments { get; set; }
	}
}