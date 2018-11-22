using InternetForum.DL.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace InternetForum.DL.Entities
{
	/// <summary>
	/// Třída obsahující hodnocení.
	/// </summary>
	public class Rating : IEntity
	{
		public Rating()
		{

		}

		/// <summary>
		/// Vrací nebo nastavuje ID tohoto hodnocení
		/// </summary>
		[Key]
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
		/// Vrací nebo nastavuje autora tohoto hodnocení.
		/// </summary>
		[Required]
		public virtual User Author { get; set; }
	}
}