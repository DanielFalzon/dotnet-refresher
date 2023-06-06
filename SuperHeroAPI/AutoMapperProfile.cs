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
		}
	}
}

