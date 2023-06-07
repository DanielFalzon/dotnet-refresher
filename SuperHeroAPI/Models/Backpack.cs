using System.Text.Json.Serialization;

namespace SuperHeroAPI.Models
{
    public class Backpack
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SuperHeroId { get; set; }
        //Set as JsonIgnore since a loop is created when building the response. Something to consider in the DTO.
        [JsonIgnore]
        public SuperHero SuperHero { get; set; }
    }
}
