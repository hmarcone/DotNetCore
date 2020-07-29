using AutoMapper;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Identity;
using ProAgil.Infrastructure.DbModels;
using ProAgil.Infrastructure.DbModels.Identity;
using System.Linq;

namespace ProAgil.WebApi.Helpers
{
	public class AutoMapperProfiles : Profile
	{

		public AutoMapperProfiles()
		{
			CreateMap<Evento, EventoModel>()
				.ForMember(dest => dest.Palestrantes, opt =>
				{
					opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
				})
				.ReverseMap();

			//ToDo: forma dificil de resolver a questão do palestrantes eventos
			//CreateMap<EventoModel, Evento>()
			//	.ForMember(dest => dest.PalestrantesEventos.Select(x => x.Palestrante).ToList(), opt =>
			//	{
			//		opt.MapFrom(src => src.Palestrantes);
			//	});

			CreateMap<Palestrante, PalestranteModel>()
				.ForMember(dest => dest.Eventos, opt =>
				{
					opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
				})
				.ReverseMap();

			CreateMap<Lote, LoteModel>().ReverseMap();
			CreateMap<RedeSocial, RedeSocialModel>().ReverseMap();

			CreateMap<User, UserModel>().ReverseMap();
			CreateMap<User, UserLoginModel>().ReverseMap();

		}
	}
}
