using AutoMapper;
using ProAgil.Domain.Entities;
using ProAgil.Infrastructure.DbModels;
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

			CreateMap<Palestrante, PalestranteModel>()
				.ForMember(dest => dest.Eventos, opt =>
				{
					opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
				})
				.ReverseMap();

			CreateMap<Lote, LoteModel>().ReverseMap();
			CreateMap<RedeSocial, RedeSocialModel>().ReverseMap();

		}
	}
}
