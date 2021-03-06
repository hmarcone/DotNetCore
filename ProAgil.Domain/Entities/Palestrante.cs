﻿using ProAgil.Domain.Core;
using System.Collections.Generic;

namespace ProAgil.Domain.Entities
{
	public class Palestrante : Entity
	{
		public string MiniCurriculo { get; private set; }
		public string ImagemURL { get; private set; }
		public string Telefone { get; private set; }
		public string Email { get; private set; }
		public List<RedeSocial> RedesSociais { get; private set; }
		public List<PalestranteEvento> PalestrantesEventos { get; private set; }
	}
}