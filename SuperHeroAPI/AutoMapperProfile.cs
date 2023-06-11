using System;
using AutoMapper;
using SuperHeroAPI.Models.DTOs;

namespace SuperHeroAPI
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<SuperHero, SuperHeroDto>();
			CreateMap<SuperHeroDto, SuperHero>();

			CreateMap<Weapon, WeaponCreateDto>();
            CreateMap<Weapon, WeaponGetDto>();
            CreateMap<WeaponCreateDto, Weapon>();
			CreateMap<WeaponGetDto, Weapon>();
		}
	}
}

