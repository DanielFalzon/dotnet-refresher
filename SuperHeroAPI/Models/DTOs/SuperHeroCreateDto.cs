namespace SuperHeroAPI.Models.DTOs
{
    //TODO: Update this to only include IDs of Weapons and IDs of factions
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
