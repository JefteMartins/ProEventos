using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace Proeventos.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string URL { get; set; }

        public int? EventoID { get; set; }

        public Evento Evento { get; set; }

        public int? PalestranteID { get; set; }

        public Palestrante Palestrante { get; set; }
    }
}