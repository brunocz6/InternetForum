using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class EditPostViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje Id příspěvku.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nadpis příspěvku.
		/// </summary>
		[MaxLength(100)]
		public string Title { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje obsah příspěvku.
		/// </summary>
		[MaxLength(2000)]
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kterého vlákna je příspěvek součástí.
		/// </summary>
		public int ForumThreadId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje komentáře příspěvku.
		/// </summary>
		public IEnumerable<CommentViewModel> Comments { get; set; }
	}
}
