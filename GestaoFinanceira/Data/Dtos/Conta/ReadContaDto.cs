using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Data.Dtos.Conta
{
    public class ReadContaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo DataHora é obrigatório")]
        public DateTime DataHora { get; set; }
        public double Valor { get; set; }

        [Required(ErrorMessage = "O Campo Descricao é obrigatório")]
        [StringLength(100, ErrorMessage = "O limite do campo Descricao é de 100 caracteries")]
        public string Descricao { get; set; }
    }
}
