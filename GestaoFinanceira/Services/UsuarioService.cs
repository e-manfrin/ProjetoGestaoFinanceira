using AutoMapper;
using FluentResults;
using GestaoFinanceira.Data;
using GestaoFinanceira.Data.Dtos.Usuario;
using GestaoFinanceira.Models;

namespace GestaoFinanceira.Services
{
    public class UsuarioService
    {
        private AppDbContext _context;
        private IMapper _mapper;


        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadUsuarioDto AdicionaUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return _mapper.Map<ReadUsuarioDto>(usuario);
        }

        public List<ReadUsuarioDto> RecuperarUsuario(string nomeDoUsuario)
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            if (usuarios == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadUsuarioDto>>(usuarios);
        }

        public ReadUsuarioDto RecuperarUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(conta => conta.IdUsuario == id);
            if (usuario == null)
            {
                return null;
            }
            return _mapper.Map<ReadUsuarioDto>(usuario);
        }

        public ReadUsuarioDto RecuperaUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(conta => conta.IdUsuario == id);
            if (usuario != null)
            {
                return _mapper.Map<ReadUsuarioDto>(usuario);
            }
            return null;
        }

        public Result RecuperaUsuarioPorId(int id, UpdateUsuarioDto usuarioDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == id);
            if (usuario == null)
            {
                return Result.Fail("Usuario não encontrado");
            }
            _mapper.Map(usuarioDto, usuario);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == id);
            if (usuario == null)
            {
                return Result.Fail("Usuario não encontrado");
            }

            _context.Remove(usuario);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

