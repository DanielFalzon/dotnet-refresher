using System;

namespace SuperHeroAPI.Services.SuperHeroService
{
	public class SuperHeroService: ISuperHeroService
	{
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
		{
            _context = context;
        }


        public List<SuperHero> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            _context.SaveChanges();

            return _context.SuperHeroes.ToList<SuperHero>();
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            SuperHero? hero = _context.SuperHeroes.Find(id);

            if (hero is null) return null;

            _context.SuperHeroes.Remove(hero);

            _context.SaveChanges();

            return _context.SuperHeroes.ToList<SuperHero>();
        }

        public List<SuperHero> GetAllHeroes()
        {
            List<SuperHero> heroes = _context.SuperHeroes.ToList<SuperHero>();
            return heroes;
        }

        public SuperHero? GetSingleHero(int id)
        {
            SuperHero? hero = _context.SuperHeroes.Find(id);

            if (hero is null) return null;

            return hero;
        }

        //To Add DTOs
        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            SuperHero? hero = _context.SuperHeroes.Find(id);

            if (hero is null) return null;

            hero.Firstname = !String.IsNullOrEmpty(request.Firstname) ? request.Firstname : hero.Firstname;
            hero.Lastname = !String.IsNullOrEmpty(request.Lastname) ? request.Lastname : hero.Lastname;
            hero.Name = !String.IsNullOrEmpty(request.Name) ? request.Name : hero.Name;
            hero.Place = !String.IsNullOrEmpty(request.Place) ? request.Place : hero.Place;
            //hero.Movies = _context.Movies.Where(m => m.SuperHeroes.Where(sh => sh.Id == id))

            _context.SaveChanges();
             
            return _context.SuperHeroes.ToList();
        }
    }
}