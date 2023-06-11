using Azure.Core;

namespace SuperHeroAPI.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {

        private readonly DataContext _context;

        public WeaponService(DataContext context)
        {
            _context = context;
        }

        public List<Weapon> AddWeapon(Weapon weapon)
        {
            _context.Weapons.Add(weapon);
            _context.SaveChanges();

            return _context.Weapons.ToList<Weapon>();
        }

        public List<Weapon>? DeleteWeapon(int id)
        {
            Weapon? weapon = _context.Weapons.Find(id);

            if (weapon is null) return null;

            _context.Weapons.Remove(weapon);
            _context.SaveChanges();

            return _context.Weapons.ToList<Weapon>();
        }

        public List<Weapon> GetAllWeapons()
        {
            return _context.Weapons.ToList<Weapon>();  
        }

        public Weapon? GetSingleWeapon(int id)
        {
            return _context.Weapons.Find(id);
        }

        public List<Weapon>? UpdateWeapon(int id, Weapon weapon)
        {
            Weapon? weaponToUpdate = _context.Weapons.Find(id);

            if (weaponToUpdate is null) return null;

            weaponToUpdate.Name = !string.IsNullOrEmpty(weapon.Name) ? weapon.Name : weaponToUpdate.Name;

            if(weapon.SuperHeroId >= 0)
            {
                SuperHero? superHero = _context.SuperHeroes.Find(weapon.SuperHeroId);
                weaponToUpdate.SuperHero = superHero != null ? superHero : weaponToUpdate.SuperHero;
            }

            _context.SaveChanges();

            return _context.Weapons.ToList<Weapon>();

        }
    }
}
