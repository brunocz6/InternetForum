using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class UserViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje ID uživatele.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje jméno uživatele.
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje URL adresu profilového obrázku tohoto uživatele.
		/// </summary>
		public string AvatarURL { get; set; }
	}
}