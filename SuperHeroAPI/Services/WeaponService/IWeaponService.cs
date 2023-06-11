namespace SuperHeroAPI.Services.WeaponService
{
    public interface IWeaponService
    {
        public List<Weapon> GetAllWeapons();
        public Weapon? GetSingleWeapon(int id);
        public List<Weapon> AddWeapon(Weapon weapon);
        public List<Weapon>? UpdateWeapon(int id, Weapon weapon);
        public List<Weapon>? DeleteWeapon (int id);
    }
}
