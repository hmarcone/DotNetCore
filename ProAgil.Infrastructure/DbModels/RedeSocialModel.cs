using System.ComponentModel.DataAnnotations;

namespace ProAgil.Infrastructure.DbModels
{
    public class RedeSocialModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string URL { get; set; }
	}
}