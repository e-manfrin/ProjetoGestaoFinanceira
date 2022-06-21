using AutoMapper;
using GestaoFinanceira.Data.Dtos.Usuario;
using GestaoFinanceira.Models;

namespace GestaoFinanceira.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, ReadUsuarioDto>();
            CreateMap<UpdateUsuarioDto, Usuario>();
        }
    }
}
