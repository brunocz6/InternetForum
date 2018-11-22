using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Entities
{
	public class ForumThreadUser
	{
		public ForumThreadUser()
		{

		}

		public ForumThreadUser(string userId, int forumThreadId)
		{
			this.UserId = userId;
			this.ForumThreadId = forumThreadId;
		}

		/// <summary>
		/// Vrací nebo nastavuje Id vlákna.
		/// </summary>
		public int ForumThreadId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje Id uživatele.
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje vlákno.
		/// </summary>
		public virtual ForumThread ForumThread { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje uživatele.
		/// </summary>
		public virtual User User { get; set; }
	}
}