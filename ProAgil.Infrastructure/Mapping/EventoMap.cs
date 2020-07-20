using AutoMapper;
using ProAgil.Domain.Entities;
using ProAgil.Infrastructure.DbModels;
using System.Linq;

namespace ProAgil.Infrastructure.Mapping
{
	public class EventoMap : Profile
	{
		public EventoMap()
		{

			CreateMap<Evento, EventoModel>()
				.ForMember(dest => dest.Palestrantes, opt =>
				{
					opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
				});

			//CreateMap<Evento, EventoModel>()
			//.ForMember(dest => dest.Palestrantes, opt =>
			//{
			//	opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
			//});

			CreateMap<Palestrante, PalestranteModel>()
				.ForMember(dest => dest.Eventos, opt =>
				{
					opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
				});

			//public DateTime DataEvento { get; private set; }
			//public int QtdPessoas { get; private set; }
			////public string ImagemURL { get; private set; }
			//public string Telefone { get; private set; }
			//public string Email { get; private set; }
			//public List<Lote> Lotes { get; private set; }
			//public List<RedeSocial> RedesSociais { get; private set; }
			//public List<PalestranteEvento> PalestrantesEventos { get; private set; }

			//Mapper.Configuration.AssertConfigurationIsValid();
			//Mapper.Initialize(cfg => cfg.ValidateInlineMaps = false);
			//Mapper.Initialize(cfg => cfg.EnableNullPropagationForQueryMapping = false);

			//AllowNullDestinationValues = true;

			//CreateMap<EventoModel, Evento>(MemberList.None);
			//.ForMember(dest => dest.PalestrantesEventos, m => m.Ignore())
			//.ForMember(dest => dest.Nome, m => m.Ignore())
			//.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
			//.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Tema))
			//.ForMember(dest => dest.Local, opt => opt.MapFrom(src => src.Local))
			//.ForMember(dest => dest.DataEvento, opt => opt.MapFrom(src => src.DataEvento))
			//.ForMember(dest => dest.ImagemURL, opt => opt.MapFrom(src => src.ImagemURL))
			//.ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
			//.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
			//.ForMember(dest => dest.Lotes, opt => opt.MapFrom(src => src.Lotes))
			//.ForMember(dest => dest.RedesSociais, opt => opt.MapFrom(src => src.RedesSociais));


			//CreateMap<Evento, EventoModel>(MemberList.None);
			//.ForMember(dest => dest.Tema, m => m.Ignore())
			//.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
			//.ForMember(dest => dest.Tema, opt => opt.MapFrom(src => src.Nome))
			//.ForMember(dest => dest.Local, opt => opt.MapFrom(src => src.Local))
			//.ForMember(dest => dest.DataEvento, opt => opt.MapFrom(src => src.DataEvento))
			//.ForMember(dest => dest.ImagemURL, opt => opt.MapFrom(src => src.ImagemURL))
			//.ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
			//.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
			//.ForMember(dest => dest.Lotes, opt => opt.MapFrom(src => src.Lotes))
			//.ForMember(dest => dest.RedesSociais, opt => opt.MapFrom(src => src.RedesSociais))
			//.ForMember(dest => dest.Palestrantes, opt =>
			//{
			//    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
			//});

			//.ForMember(dest => dest.Palestrantes, opt =>
			//{
			//    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
			//})
			//.ReverseMap();

			//cfg.ForAllMaps((typeMap, mappingExpr) =>
			//{
			//    var ignoredPropMaps = typeMap.GetPropertyMaps();

			//    foreach (var map in ignoredPropMaps)
			//    {
			//        var sourcePropInfo = map.SourceMember as PropertyInfo;
			//        if (sourcePropInfo == null) continue;

			//        if (sourcePropInfo.PropertyType != map.DestinationPropertyType)
			//            throw new Exception("Wrong property type!");
			//    }
			//});
			//var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<EventoModel, Evento>()
			//    .ForAllMembers(opt => opt.Condition(IsValidType))); //and how to conditionally ignore properties
		}

		//private bool IsValidType(ResolutionContext arg1, Evento arg2, object arg3, object arg4, ResolutionContext arg5)
		//{
		//    var isSameType = arg1.Options. == arg2.Nome;
		//    return isSameType;
		//}

		//private static bool IsValidType(ResolutionContext arg)
		//{
		//    var isSameType = arg.SourceType == arg.DestinationType; //is source and destination type is same?
		//    return isSameType;
		//}

	}
}
