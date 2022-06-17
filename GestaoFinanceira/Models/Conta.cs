using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Models
{
    public class Conta
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

        public Conta(int id, DateTime dataHora, double valor, string descricao)
        {
            this.Id = id;
            this.DataHora = dataHora;   
            this.Valor = valor;
            this.Descricao = descricao;
        }

        public Conta() { }
    }
}
