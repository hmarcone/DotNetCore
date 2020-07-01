using System;

namespace ProAgil.Domain
{
    public class Lote
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime? DataInicio{ get; private set; }
        public DateTime? DataFim { get; private set; }
        public int Quantidade { get; private set; }
        public int EventoId { get; private set; }
        public Evento Evento { get; private set; }
    }
}
