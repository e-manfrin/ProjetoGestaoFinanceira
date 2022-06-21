using FluentResults;
using GestaoFinanceira.Data.Dtos.Usuario;
using GestaoFinanceira.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFinanceira.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class UsuarioController : ControllerBase
        {
            private UsuarioService _usuarioService;

            public UsuarioController(UsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }

            [HttpPost]
            public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto)
            {
                ReadUsuarioDto readDto = _usuarioService.AdicionaUsuario(usuarioDto);
                return CreatedAtAction(nameof(RecuperaUsuarioPorId), new { Id = readDto.IdUsuario }, readDto);
            }

            [HttpGet]
            public IActionResult RecuperarUsuario([FromQuery] string nomeDoUsuario)
            {
                List<ReadUsuarioDto> readDto = _usuarioService.RecuperarUsuario(nomeDoUsuario);
                if (readDto == null) return NotFound();
                return Ok(readDto);
            }

            [HttpGet("{id}")]
            public IActionResult RecuperarUsuarioPorId(int id)
            {
                ReadUsuarioDto readDto = _usuarioService.RecuperarUsuarioPorId(id);
                if (readDto == null) return NotFound();
                return Ok(readDto);
            }

            [HttpPut("{id}")]
            public IActionResult RecuperaUsuarioPorId(int id, [FromBody] UpdateUsuarioDto usuarioDto)
            {
                Result resultado = _usuarioService.RecuperaUsuarioPorId(id, usuarioDto);
                if (resultado.IsFailed) return NotFound();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult DeletaUsuario(int id)
            {
                Result resultado = _usuarioService.DeletaUsuario(id);
                if (resultado.IsFailed) return NotFound();
                return NoContent();
            }
        }
    }