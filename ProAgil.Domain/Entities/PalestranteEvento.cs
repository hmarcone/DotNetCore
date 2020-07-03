using System.Collections.Generic;

namespace ProAgil.Domain.Entities
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; private set; }
        public Palestrante Palestrante { get; private set; }
        public int EventoId { get; private set; }
        public Evento Evento { get; private set; }
    }
}