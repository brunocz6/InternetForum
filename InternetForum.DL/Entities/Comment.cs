using InternetForum.DL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetForum.DL.Entities
{
	public class Comment : IEntity
	{
		/// <summary>
		/// Vrací nebo nastavuje ID komentáře.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje text komentáře.
		/// </summary>
		[MaxLength(255)]
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy byl příspěvek vytvořen.
		/// </summary>
		[Required]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje autora komentáře
		/// </summary>
		[Required]
		public virtual User Author { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje příspěvek, pod který komentář patří.
		/// </summary>
		[Required]
		public virtual Post Post { get; set; }

		///// <summary>
		///// Vrací nebo nastavuje komentáře spadající pod tento komentář.
		///// </summary>
		//public virtual ICollection<Comment> Comments { get; set; }
	}
}