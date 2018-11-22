using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class ThreadInfoViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje počet odběratelů vlákna.
		/// </summary>
		public string SubscribersCount { get; set; }
	}
}