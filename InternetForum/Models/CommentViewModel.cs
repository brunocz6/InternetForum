using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class CommentViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID komentáře.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nadpis komentáře.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah komentáře.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy byl tento komentář vytvořen.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje autora tohoto komentáře.
		/// </summary>
		public UserViewModel Author { get; set; }
	}
}
