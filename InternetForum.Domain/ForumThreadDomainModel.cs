using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetForum.Domain
{
	public class ForumThreadDomainModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID vlákna.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje odběratele tohoto vlákna.
		/// </summary>
		public IEnumerable<UserDomainModel> Subscribers { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje posty, které spadají pod toto vlákno.
		/// </summary>
		public IEnumerable<PostDomainModel> Posts { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje počet odběratelů tohoto vlákna.
		/// </summary>
		public int SubscribersCount
		{
			get
			{
				return this.Subscribers.Count();
			}
		}
	}
}