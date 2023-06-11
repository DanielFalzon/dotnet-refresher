namespace SuperHeroAPI.Models.DTOs
{
    //TODO: Check for uniqueness when creating a faction
    public record struct FactionGetDto( int id, string Name );
}
