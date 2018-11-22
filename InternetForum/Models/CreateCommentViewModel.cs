using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class CreateCommentViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje obsah komentáře. 
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje ke kterému příspěvku komentář patří.
		/// </summary>
		public int PostId { get; set; }
	}
}