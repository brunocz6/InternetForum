using InternetForum.DL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetForum.DL.Entities
{
	/// <summary>
	/// Forum vlákno.
	/// </summary>
	public class ForumThread : IEntity
	{
		/// <summary>
		/// Vrací nebo nastavuje ID vlákna.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		[MaxLength(100)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy bylo vlákno vytvořeno.
		/// </summary>
		[Required]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		[Required]
		public string Description { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje odběratele tohoto vlákna.
		/// </summary>
		public virtual IEnumerable<ForumThreadUser> Subscribers { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje posty, které spadají pod toto vlákno.
		/// </summary>
		public virtual IEnumerable<Post> Posts { get; set; }
	}
}