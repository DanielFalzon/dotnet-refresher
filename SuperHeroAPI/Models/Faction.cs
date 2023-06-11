using System.Text.Json.Serialization;

namespace SuperHeroAPI.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<SuperHero> SuperHeroes { get; set; } = new List<SuperHero>();
    }
}
