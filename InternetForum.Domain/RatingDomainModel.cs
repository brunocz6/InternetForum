using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.Domain
{
	public class RatingDomainModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID tohoto hodnocení
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje počet kladných hodnocení.
		/// </summary>
		public int Upvotes { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje počet negativních hodnocení.
		/// </summary>
		public int Downvotes { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje uživatele, který toto hodnocení vytvořil.
		/// </summary>
		public UserDomainModel Author { get; set; }
	}
}