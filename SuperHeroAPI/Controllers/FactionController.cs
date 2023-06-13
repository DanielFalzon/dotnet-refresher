using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models.DTOs;
using SuperHeroAPI.Services.FactionService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactionController : ControllerBase
    {
        private readonly IFactionService _factionService;
        private readonly IMapper _mapper;

        public FactionController(IFactionService factionService, IMapper mapper)
        {
            _factionService = factionService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<FactionGetDto>> GetAllFactions()
        {
            return Ok(
                _factionService.GetAllFactions()
                    .Select(_mapper.Map<FactionGetDto>).ToList()
            );
        }

        [HttpGet("{id}")]
        public ActionResult<FactionGetDto> GetSingleFaction(int id)
        {
            Faction? faction = _factionService.GetSingleFaction(id);

            if (faction == null) return NotFound("Faction wiuth provided Id not found.");

            return Ok(
                _mapper.Map<FactionGetDto>(faction)
            );
        }

        [HttpPost]
        public ActionResult<List<FactionGetDto>> CreateFaction(FactionCreateDto faction) 
        {
            Faction newFaction = _mapper.Map<Faction>(faction);

            List<Faction> factions = _factionService.AddFaction(newFaction);

            return Ok(
                factions.Select(_mapper.Map<FactionGetDto>).ToList()
            );
        }

        [HttpPut("{id}")]
        public ActionResult<List<FactionGetDto>> UpdateFaction(int id, FactionCreateDto faction) 
        { 
            Faction factionToUpdate = _mapper.Map<Faction>(faction);
            List<Faction>? factions = _factionService.UpdateFaction(id, factionToUpdate);

            if (factions == null) return NotFound($"Faction with id {id} not found.");

            return Ok(
                factions.Select(_mapper.Map<FactionGetDto>)
            );
        }
    }
}
