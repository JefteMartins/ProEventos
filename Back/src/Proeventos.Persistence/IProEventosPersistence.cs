using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace Proeventos.Persistence
{
    public interface IProEventosPersistence
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityArray) where T : class;

        Task<bool> SaveChangesAsync();

        //eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
        //palestrantes
        Task<Evento[]> GetAllPalestrantesAsync(bool includePalestrantes);
        Task<Evento[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos);
        Task<Evento[]> GetAllPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}