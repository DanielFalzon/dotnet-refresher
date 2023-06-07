namespace SuperHeroAPI.Models.DTOs
{
    public record struct SuperHeroCreateDto ( 
        string Name,
        string Firstname,
        string Lastname,
        string Place,
        BackpackCreateDto Backpack,
        List<WeaponCreateDto> Weapons,
        List<FactionCreateDto> Factions
    );
}
