namespace SuperHeroAPI.Services.FactionService
{
    public interface IFactionService
    {
        public List<Faction> GetAllFactions();
        public Faction? GetSingleFaction(int id);
        public List<Faction> AddFaction(Faction faction);
        public List<Faction>? UpdateFaction(int id, Faction faction);
        public List<Faction>? DeleteFaction(int id);
    }
}
