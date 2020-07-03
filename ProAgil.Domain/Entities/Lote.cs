using ProAgil.Domain.Core;
using System;

namespace ProAgil.Domain.Entities
{
    public class Lote : Entity
    {
        public decimal Preco { get; private set; }
        public DateTime? DataInicio{ get; private set; }
        public DateTime? DataFim { get; private set; }
        public int Quantidade { get; private set; }
        public int EventoId { get; private set; }
        public Evento Evento { get; }
    }
}
