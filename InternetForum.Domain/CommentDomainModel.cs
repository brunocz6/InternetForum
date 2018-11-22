using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.Domain
{
	public class CommentDomainModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID komentáře.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje text komentáře.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje autora komentáře
		/// </summary>
		public UserDomainModel Author { get; set; }

		// Viz. Comment entita
		///// <summary>
		///// Vrací nebo nastavuje komentáře spadající pod tento komentář.
		///// </summary>
		//public IEnumerable<CommentDomainModel> Comments { get; set; }
	}
}