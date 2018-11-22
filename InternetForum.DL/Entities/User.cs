using InternetForum.DL.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetForum.DL.Entities
{
	public class User : IdentityUser, IEntity
	{
		public async Task<IdentityResult> GenerateUserIdentityAsync(AspNetUserManager<User> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateAsync(this);
			// Add custom user claims here
			return userIdentity;
		}

		/// <summary>
		/// Vrací nebo nastavuje URL adresu profilového obrázku.
		/// </summary>
		public string AvatarURL { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje hodnocení uživatele.
		/// </summary>
		public virtual ICollection<Rating> Ratings { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje vlákna, která uživatel odebírá.
		/// </summary>
		public virtual ICollection<ForumThreadUser> SubscribedForumThreads { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci příspevků tohoto uživatele.
		/// </summary>
		public virtual ICollection<Post> Posts { get; set; }
	}
}