using AutoMapper;
using SuperHeroAPI.Builders;
using SuperHeroAPI.Models.DTOs;
using SuperHeroAPI.Services.FactionService;

namespace SuperHeroAPI
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			//TODO: Go through these mappings to check if they are infact needed (Create -> Model makes sense but not Model -> Create)
			CreateMap<SuperHero, SuperHeroDto>();
			CreateMap<SuperHeroDto, SuperHero>();

			//Note: On the reverse map, any superhero that's created with a facction ID is mapped to the corresponding faction when passed
			CreateMap<SuperHeroCreateDto, SuperHero>().ConvertUsing<SuperHeroTypeConvertor>();

			CreateMap<BackpackCreateDto, Backpack>();

            CreateMap<Weapon, WeaponCreateDto>().ReverseMap();
            CreateMap<Weapon, WeaponGetDto>().ReverseMap();

			CreateMap<Faction, FactionCreateDto>().ReverseMap();
			CreateMap<Faction, FactionGetDto>().ReverseMap();
		}
	}

	public class SuperHeroTypeConvertor : ITypeConverter<SuperHeroCreateDto, SuperHero>
	{
		private readonly IFactionService _factionService;

        public SuperHeroTypeConvertor(IFactionService factionService)
        {
            _factionService = factionService;
        }

        public SuperHero Convert(SuperHeroCreateDto source, SuperHero destination, ResolutionContext context)
		{
            //TODO: Investigate why this is allowed when the Backpack class requires the SuperHero model to be set. 
            Backpack backpack = context.Mapper.Map<Backpack>(source.Backpack);

			SuperHeroBuilder superHeroBuilder = new SuperHeroBuilder(backpack)
				.WithName(source.Name)
				.WithFirstName(source.Firstname)
				.WithLastName(source.Lastname)
				.WithPlace(source.Place);

			//NOTE: Where clause isn't recogninzed at compile time. OfType used to tell compiler that nulls are filtered out.
            List<Faction> factions = source.FactionIds
                .Select(_factionService.GetSingleFaction)
                .OfType<Faction>()
                .ToList();

			superHeroBuilder.WithFactions(factions);

			SuperHero hero = superHeroBuilder.Build();
			backpack.SuperHero = hero;

            return superHeroBuilder.Build(); ;
		}
	}
}

