using System.Text.Json.Serialization;

namespace SuperHeroAPI.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<SuperHero> SuperHeroes { get; set; }
    }
}
