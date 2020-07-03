using ProAgil.Domain.Core;

namespace ProAgil.Domain.Entities
{
    public class RedeSocial : Entity
    {
        public string URL { get; set; }
        public int? EventoId { get; private set; }
        public Evento Evento { get; }
        public int? PalestranteId { get; private set; }
        public Palestrante Palestrante { get; }
    }
}