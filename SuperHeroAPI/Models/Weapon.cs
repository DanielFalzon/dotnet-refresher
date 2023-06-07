using System.Text.Json.Serialization;

namespace SuperHeroAPI.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SuperHeroId { get; set; }
        [JsonIgnore]
        public SuperHero SuperHero { get; set; }
    }
}
