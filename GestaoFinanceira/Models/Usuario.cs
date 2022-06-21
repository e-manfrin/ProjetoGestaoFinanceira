using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int IdUsuario { get; set; }

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

        public Usuario(int idUsuario, string nome, string emailLogin,
            string senha, DateTime dataHoraCriacao, string usuarioCriacao,
            DateTime dataHoraAlteracao, string usuarioAlteracao)
        {
            this.IdUsuario = idUsuario;
            this.Nome = nome;
            this.EmailLogin = emailLogin;
            this.Senha = senha;
            this.DataHoraCriacao = dataHoraCriacao;
            this.UsuarioCriacao = usuarioCriacao;
            this.DataHoraAlteracao = dataHoraAlteracao;
            this.UsuarioAlteracao = usuarioAlteracao;
        }

        public Usuario() { }
    }
}

