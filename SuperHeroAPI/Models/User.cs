using System;
namespace SuperHeroAPI.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public List<SuperHero> SuperHeroes { get; set; }
	}
}

