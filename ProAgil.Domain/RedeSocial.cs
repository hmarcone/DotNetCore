namespace ProAgil.Domain
{
    public class RedeSocial
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string URL { get; private set; }
        public int? EventoId { get; private set; }
        public Evento Evento { get; }
        public int? PalestranteId { get; private set; }
        public Palestrante Palestrante { get; }
    }
}