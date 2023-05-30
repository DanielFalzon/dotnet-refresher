using System;
namespace SuperHeroAPI.Models
{
	public class SuperHero
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
		public string Middlename { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
		public List<Movie> Movies { get; set; } = new List<Movie>();
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateModified { get; set; }

        public SuperHero()
		{
		}
	}
}

