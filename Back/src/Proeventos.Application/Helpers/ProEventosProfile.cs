using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain;

namespace ProEventos.Application.Helpers
{
    public class ProEventosProfile: Profile
    {
        public ProEventosProfile()
        {
         CreateMap<Palestrante, PalestranteDto>().ReverseMap();
         CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
         CreateMap<Evento, EventoDto>().ReverseMap();
         CreateMap<Lote, LoteDto>().ReverseMap();
        }
    }
}