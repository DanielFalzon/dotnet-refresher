using System;
namespace SuperHeroAPI.Models.DTOs
{
	public class SuperHeroDto
	{
        public string Name { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
	}

    public record struct SuperHeroGetDto (
        string Name,
        string Firstname,
        string Lastname,
        string Place,
        BackpackCreateDto Backpack,
        List<WeaponCreateDto> Weapons,
        List<FactionCreateDto> Factions
    );
}

