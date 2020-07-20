using ProAgil.Domain.Core;
using System;
using System.Collections.Generic;

namespace ProAgil.Domain.Entities
{
	public class Evento : Entity
	{
		public string Local { get; set; }
		public DateTime DataEvento { get; set; }
		public int QtdPessoas { get; set; }
		public string ImagemURL { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public List<Lote> Lotes { get; set; }
		public List<RedeSocial> RedesSociais { get; set; }
		public List<PalestranteEvento> PalestrantesEventos { get; set; }
	}
}