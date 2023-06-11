namespace SuperHeroAPI.Services.FactionService
{
    public class FactionService : IFactionService
    {
        private readonly DataContext _context;

        public FactionService(DataContext context)
        {
            _context = context;
        }

        public List<Faction> AddFaction(Faction faction)
        {
            _context.Factions.Add(faction);

            return _context.Factions.ToList<Faction>();
        }

        public List<Faction>? DeleteFaction(int id)
        {
            Faction? faction = _context.Factions.Find(id);

            if (faction is null) return null;

            _context.Factions.Remove(faction);
            _context.SaveChanges();

            return _context.Factions.ToList<Faction>();
        }

        public List<Faction> GetAllFactions()
        {
            return _context.Factions.ToList<Faction>(); 
        }

        public Faction? GetSingleFaction(int id)
        {
            return _context.Factions.Find(id);
        }

        public List<Faction>? UpdateFaction(int id, Faction faction)
        {
            Faction? factionToUpdate = _context.Factions.Find(id);

            if (factionToUpdate is null) return null;

            factionToUpdate.Name = faction.Name;

            _context.SaveChanges();

            return _context.Factions.ToList<Faction>();
        }
    }
}
