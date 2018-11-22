using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class HomeIndexViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje kolekci příspěvků.
		/// </summary>
		public IEnumerable<PostViewModel> Posts { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje nejvíce odebíraná vlákna.
		/// </summary>
		public IEnumerable<ThreadInfoViewModel> MostSubscribedThreads { get; set; }
	}
}