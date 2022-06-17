using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Dtos
{
    public class CreateContaDto
    {
        [Required(ErrorMessage = "O Campo DataHora é obrigatório")]
        public DateTime DataHora { get; set; }
        public double Valor { get; set; }

        [Required(ErrorMessage = "O Campo Descricao é obrigatório")]
        [StringLength(100, ErrorMessage = "O limite do campo Descricao é de 100 caracteries")]
        public string Descricao { get; set; }
    }
}
