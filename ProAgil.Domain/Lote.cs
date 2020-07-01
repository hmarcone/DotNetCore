using System;

namespace ProAgil.Domain
{
    public class Lote : EntityBase
    {
        public decimal Preco { get; private set; }
        public DateTime? DataInicio{ get; private set; }
        public DateTime? DataFim { get; private set; }
        public int Quantidade { get; private set; }
        public int EventoId { get; private set; }
        public Evento Evento { get; private set; }
    }
}
