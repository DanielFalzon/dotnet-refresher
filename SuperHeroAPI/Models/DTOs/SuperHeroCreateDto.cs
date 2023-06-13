namespace SuperHeroAPI.Models.DTOs
{
    //TODO: Update this to create weapons with creation of superhero
    public record struct SuperHeroCreateDto ( 
        string Name,
        string Firstname,
        string Lastname,
        string Place,
        List<int> FactionIds,
        BackpackCreateDto Backpack
    );
}
