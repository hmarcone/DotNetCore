using AutoMapper;
using ProAgil.Domain.Entities;
using ProAgil.Infrastructure.DbModels;
using System.Linq;

namespace ProAgil.Infrastructure.Mapping
{
	public class PalestranteMap : Profile
	{
		public PalestranteMap()
		{
			CreateMap<Palestrante, PalestranteModel>()
				.ForMember(dest => dest.Eventos, opt =>
				{
					opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
				});
		}
	}
}
