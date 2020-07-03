using ProAgil.Domain.Core;
using System;
using System.Collections.Generic;

namespace ProAgil.Domain.Entities
{
    public class Evento: Entity
    {
        public string Local { get; private set; }
        public DateTime DataEvento { get; private set; }
        public int QtdPessoas { get; private set; }
        public string ImagemURL { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public List<Lote> Lotes { get; private set; }
        public List<RedeSocial> RedesSociais { get; private set; }
        public List<PalestranteEvento> PalestrantesEventos { get; private set; }
    }
}