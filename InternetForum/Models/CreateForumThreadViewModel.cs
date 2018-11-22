using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class CreateForumThreadViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		public string Description { get; set; }
	}
}