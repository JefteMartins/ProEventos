using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proeventos.Domain;
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
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}