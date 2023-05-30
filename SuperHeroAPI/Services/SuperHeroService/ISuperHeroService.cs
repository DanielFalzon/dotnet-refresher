using System;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroService
{
	public interface ISuperHeroService
	{
        public List<SuperHero> GetAllHeroes();
        public SuperHero? GetSingleHero(int id);
        public List<SuperHero> AddHero(SuperHero hero);
        public List<SuperHero>? UpdateHero(int id, SuperHero request);
        public List<SuperHero>? DeleteHero(int id);
    }
}