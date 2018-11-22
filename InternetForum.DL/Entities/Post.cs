using InternetForum.DL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetForum.DL.Entities
{
	public class Post : IEntity
	{
		/// <summary>
		/// Vrací nebo nastavuje ID příspěvku.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		[Required]
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy byl příspěvek vytvořen.
		/// </summary>
		[Required]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje autora příspěvku.
		/// </summary>
		[Required]
		public virtual User Author { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kterého vlákna je příspěvek součástí.
		/// </summary>
		[Required]
		public virtual ForumThread ForumThread { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci hodnocení tohoto příspěvku.
		/// </summary>
		public virtual ICollection<Rating> Ratings { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci komentářů, které spadají pod tento příspěvek.
		/// </summary>
		public virtual ICollection<Comment> Comments { get; set; }

	}
}