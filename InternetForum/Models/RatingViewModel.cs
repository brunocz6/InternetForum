using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class RatingViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje počet kladných hodnocení.
		/// </summary>
		public int Upvotes { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje počet negativních hodnocení.
		/// </summary>
		public int Downvotes { get; set; }
	}
}