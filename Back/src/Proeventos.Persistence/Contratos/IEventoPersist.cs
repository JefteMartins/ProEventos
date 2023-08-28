using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proeventos.Domain;
using ProEventos.Domain;

namespace Proeventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        //eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}