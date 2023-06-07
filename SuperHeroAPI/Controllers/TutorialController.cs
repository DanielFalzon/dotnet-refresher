using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using SuperHeroAPI.Models.DTOs;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        private readonly DataContext _context;

        public TutorialController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            SuperHero? superHero = await _context.SuperHeroes
                .Include(s => s.Backpack)
                .Include(s => s.Factions)
                .Include(s => s.Weapons)
                .FirstOrDefaultAsync(s => s.Id == id);

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHeroCreateDto request)
        {
            //TODO: Move to superhero service
            //TODO: Leverage automapper for relations
            //TODO: Create services and endpoints to create factions, backpacks and weapons individually
            //TODO: Handle ability to create superhero with existing factions, backpacks and weapons
            var newSuperHero = new SuperHero
            {
                Name = request.Name,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Place = request.Place
            };

            var newBackpack = new Backpack
            {
                Description = request.Backpack.Description,
                SuperHero = newSuperHero,
            };

            var newWeapons = request.Weapons.Select(w => new Weapon { Name = w.Name, SuperHero = newSuperHero }).ToList();
            var newFactions = request.Factions.Select(f => new Faction { Name = f.Name, SuperHeroes = new List<SuperHero> { newSuperHero } }).ToList();

            newSuperHero.Backpack = newBackpack;
            newSuperHero.Weapons = newWeapons;
            newSuperHero.Factions = newFactions;

            _context.SuperHeroes.Add(newSuperHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.Include(c => c.Backpack).Include(c => c.Weapons).ToListAsync());
        }
    }
}
