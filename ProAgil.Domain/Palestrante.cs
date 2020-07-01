using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Palestrante
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string MiniCurriculo { get; private set; }
        public string ImagemURL { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public List<RedeSocial> RedesSociais { get; private set; }
        public List<PalestranteEvento> PalestrantesEventos { get; private set; }
    }
}