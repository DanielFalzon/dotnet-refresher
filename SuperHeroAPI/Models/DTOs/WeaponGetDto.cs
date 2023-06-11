namespace SuperHeroAPI.Models.DTOs
{
    public record struct WeaponGetDto(
        int Id,
        string Name,
        int SuperHeroId
    );
}
