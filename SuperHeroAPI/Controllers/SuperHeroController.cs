using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models.DTOs;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private ISuperHeroService _superHeroService { get; }
        private IMapper _mapper { get; }

        public SuperHeroController(ISuperHeroService superHeroService, IMapper mapper)
        {
            _superHeroService = superHeroService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<List<SuperHeroDto>> GetAllHeroes()
        {
            return Ok(
                _superHeroService.GetAllHeroes()
                    .Select(hero => _mapper.Map<SuperHeroDto>(hero))
            );
        }

        //[HttpGet]
        //[Route("/api/SuperHeroesByUser/{userId}")]
        //public ActionResult<List<SuperHeroDto>> GetAllHeroesByUserId(int userId)
        //{
        //    IEnumerable<SuperHeroDto> result = _superHeroService.GetAllHeroes()
        //        .FindAll(hero => hero.UserId == userId)
        //        .Select(hero => _mapper.Map<SuperHeroDto>(hero));

        //    return Ok(result);
        //}

        [HttpGet("{id}")]
        public ActionResult<SuperHeroDto> GetSingleHero(int id)
        {
            SuperHero? hero = _superHeroService.GetSingleHero(id);
            if (hero is null)
                return NotFound("Hero not found.");

            return Ok(_mapper.Map<SuperHeroDto>(hero));
        }

        [HttpPost]
        public ActionResult<List<SuperHeroDto>> AddHero(SuperHeroDto newHero)
        {
            //TODO: Update relations between faction + weapon and backpack data

            var hero = _mapper.Map<SuperHero>(newHero);
            var heroes = _superHeroService.AddHero(hero);

            return Ok(heroes
                    .Select(hero => _mapper.Map<SuperHeroDto>(hero))
                );
        }

        [HttpPut("{id}")]
        public ActionResult<List<SuperHeroDto>> UpdateHero(int id, SuperHeroDto updatedHero)
        {
            //TODO: Update relations between faction + weapon and backpack data

            var hero = _mapper.Map<SuperHero>(updatedHero);
            List<SuperHero>? heroes = _superHeroService.UpdateHero(id, hero);

            if (heroes is null)
                return NotFound("Hero not found");

            return Ok(heroes
                .Select(hero => _mapper.Map<SuperHeroDto>(hero))
            );
        }

        [HttpDelete("{id}")]
        public ActionResult<List<SuperHeroDto>> DeleteHero(int id)
        {
            List<SuperHero>? heroes = _superHeroService.DeleteHero(id);

            if (heroes is null)
                return NotFound("Hero not found.");

            return Ok(heroes
                .Select(hero => _mapper.Map<SuperHeroDto>(hero))
            );
        }
    }
}
