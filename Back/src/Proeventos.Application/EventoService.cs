using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;
        public EventoService(IGeralPersist geralPersist,
                             IEventoPersist eventoPersist,
                             IMapper mapper)
        {
            _mapper = mapper;
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
        }
        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            // try
            // {
            //     _geralPersist.Add<Evento>(model);
            //     if (await _geralPersist.SaveChangesAsync())
            //     {
            //         return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
            //     }
            //     return null;
            // }
            // catch (Exception ex)
            // {
            //     throw new Exception(ex.Message);
            // }
            return null;
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            // try
            // {
            //     var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
            //     if (evento == null) return null;

            //     model.Id = evento.Id;

            //     _geralPersist.Update(model);
            //     if (await _geralPersist.SaveChangesAsync())
            //     {
            //         return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
            //     }
            //     return null;
            // }
            // catch (Exception ex)
            // {
            //     throw new Exception(ex.Message);
            // }
            return null;
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                
                var resultado =  _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                var resultado =  _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                
                var resultado =  _mapper.Map<EventoDto>(evento);
                //substitui isso aqui
                var eventoRetorno = new EventoDto(){
                    Id = resultado.Id,
                    Tema = resultado.Tema,
                    Local = resultado.Local,
                    DataEvento = resultado.DataEvento,
                    QtdPessoas = resultado.QtdPessoas,
                    ImagemURL = resultado.ImagemURL,
                    Telefone = resultado.Telefone,
                    Email = resultado.Email
                };
                

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}