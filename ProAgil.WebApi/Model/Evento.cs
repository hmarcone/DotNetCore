namespace ProAgil.WebApi.Model
{
    public class Evento
    {
        public int Id{ get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Lote { get; set; }
    }
}