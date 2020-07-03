using ProAgil.Domain.Core;
using System;

namespace ProAgil.Domain.Entities
{
    public class Lote : Entity
    {
        public decimal Preco { get; set; }
        public DateTime? DataInicio{ get;  set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; private set; }
        public Evento Evento { get; }
    }
}
