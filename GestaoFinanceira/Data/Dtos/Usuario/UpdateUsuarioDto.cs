using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Data.Dtos.Usuario
{
    public class UpdateUsuarioDto
    {
        [Required(ErrorMessage = "O Campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo Email Login é obrigatório")]
        public string EmailLogin { get; set; }

        [Required(ErrorMessage = "O Campo Senha é obrigatório")]
        [StringLength(10, ErrorMessage = "O limite do campo Descricao é de 10 caracteries")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Campo DataHora é obrigatório")]
        public DateTime DataHoraCriacao { get; set; }

        [Required(ErrorMessage = "O Campo Usuário é obrigatório")]
        public string UsuarioCriacao { get; set; }

        [Required(ErrorMessage = "O Campo DataHora é obrigatório")]
        public DateTime DataHoraAlteracao { get; set; }

        [Required(ErrorMessage = "O Campo Usuário é obrigatório")]
        public string UsuarioAlteracao { get; set; }
    }
}
