using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models.DTOs;
using SuperHeroAPI.Services.WeaponService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        private IMapper _mapper { get; }


        public WeaponController(IWeaponService weaponService, IMapper mapper)
        {
            _weaponService = weaponService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<WeaponGetDto>> GetAllWeapons()
        {
            List<WeaponGetDto> weapons = _weaponService.GetAllWeapons()
                .Select(_mapper.Map<WeaponGetDto>).ToList();

            return Ok(weapons);
        }

        [HttpGet("{id}")]
        public ActionResult<WeaponGetDto> GetWeapon(int id) 
        { 
            Weapon? weapon = _weaponService.GetSingleWeapon(id);

            if (weapon == null) NotFound("Weapon doesn't exist");

            return Ok(_mapper.Map<WeaponGetDto>(weapon));
        }

        [HttpPost]
        public ActionResult<List<WeaponGetDto>> CreateWeapon(WeaponCreateDto request)
        {
            Weapon newWeapon = _mapper.Map<Weapon>(request);

            List<WeaponGetDto> weapons = _weaponService.AddWeapon(newWeapon)
                .Select(_mapper.Map<WeaponGetDto>).ToList();

            return Ok(weapons);
        }

        [HttpPut("{id}")]
        public ActionResult<List<WeaponGetDto>> UpdateWeapon(int id, WeaponCreateDto request)
        {
            Weapon updatedWeapon = _mapper.Map<Weapon>(request);

            List<Weapon>? weapons = _weaponService.UpdateWeapon(id, updatedWeapon);

            if (weapons is null) return NotFound($"Weapon with ID {id} not found.");

            List<WeaponGetDto> weaponsRes = weapons.Select(weapon => _mapper.Map<WeaponGetDto>(weapon)).ToList();

            return Ok(weapons);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<WeaponGetDto>> DeleteWeapon(int id) 
        {
            List<Weapon>? weapons = _weaponService.DeleteWeapon(id);

            if (weapons is null) return NotFound($"Weapon with ID {id} not found.");

            List<WeaponGetDto> weaponsRes = weapons.Select(_mapper.Map<WeaponGetDto>).ToList();

            return Ok(weapons);
        }
    }
}
