using System;
namespace SuperHeroAPI.Models
{
	public class Movie
	{
        public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
		public List<SuperHero> SuperHeroes { get; set; } = new List<SuperHero>();
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public DateTime? DateModified { get; set; }

        public Movie()
		{	
		}
	}
}

