namespace SuperHeroAPI.Builders
{
    /* NOTE 
     * 
     * Builder pattern was utilised here due to the faction and backpack entities being required.
     * Admittedly, this is an overly complex pattern for the current requirements, but as this is 
     * a practice project, it's pretty good to get used to the pattern. 
     * 
     */
    public class SuperHeroBuilder
    {
        private readonly SuperHero _hero;

        public SuperHeroBuilder(Backpack backpack)
        {
            _hero = new SuperHero 
            {
                Backpack = backpack
            };
        }

        public SuperHeroBuilder WithName(string name) 
        {
            _hero.Name = name;
            return this;
        }

        public SuperHeroBuilder WithPlace(string place) 
        { 
            _hero.Place = place;
            return this;
        }

        public SuperHeroBuilder WithFirstName(string firstName) 
        { 
            _hero.Firstname = firstName;
            return this;
        }

        public SuperHeroBuilder WithLastName(string lastName)
        {
            _hero.Lastname = lastName;
            return this;
        }

        public SuperHeroBuilder WithFactions(List<Faction> factions)
        {
            _hero.Factions = factions;
            return this;
        }

        public SuperHero Build() 
        { 
            return _hero;
        }

    }
}
