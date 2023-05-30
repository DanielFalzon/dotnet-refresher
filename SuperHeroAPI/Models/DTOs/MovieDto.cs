using System;
namespace SuperHeroAPI.Models.DTOs
{
	public class MovieDto
	{
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
	}
}

