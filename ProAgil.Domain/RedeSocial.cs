namespace ProAgil.Domain
{
    public class RedeSocial : EntityBase
    {
        public string URL { get; private set; }
        public int? EventoId { get; private set; }
        public Evento Evento { get; }
        public int? PalestranteId { get; private set; }
        public Palestrante Palestrante { get; }
    }
}