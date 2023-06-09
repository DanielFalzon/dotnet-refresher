﻿namespace SuperHeroAPI.Models
{
	public class SuperHero
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
		public required Backpack Backpack { get; set; }
		public List<Weapon> Weapons { get; set; } = new List<Weapon>();
		public List<Faction> Factions { get; set; } = new List<Faction>();
	}
}

