namespace SuperHeroAPI.Models.DTOs
{
    //TODO: Check for uniqueness when creating a weapon
    public record struct WeaponCreateDto(
        string Name
    );
}
