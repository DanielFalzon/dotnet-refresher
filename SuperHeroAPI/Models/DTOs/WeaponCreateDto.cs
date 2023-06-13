namespace SuperHeroAPI.Models.DTOs
{
    //TODO: Check if the superhero exists when creating a weapon and linking to a superhero
    public record struct WeaponCreateDto(
        string Name,
        int SuperHeroId
    );
}
