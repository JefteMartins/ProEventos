using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;
using Proeventos.Persistence.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Contextos;

namespace Proeventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }


            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }


            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }


            query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}