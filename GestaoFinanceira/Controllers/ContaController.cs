using AutoMapper;
using GestaoFinanceira.Data;
using GestaoFinanceira.Dtos;
using GestaoFinanceira.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GestaoFinanceira.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private ContaContext _context;
        private IMapper _mapper;


        public ContaController(ContaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaConta([FromBody] CreateContaDto contaDto)
        {
            Conta conta = _mapper.Map<Conta>(contaDto);
            _context.Contas.Add(conta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaContaPorId), new { Id = conta.Id }, conta);
        }

        [HttpGet]
        public IEnumerable<Conta> RecuperarConta()
        {
            return _context.Contas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarContaPorId(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta != null)
            {
                return NotFound();
            }

            ReadContaDto contaDto = _mapper.Map<ReadContaDto>(conta);
            return Ok(contaDto);

        }

        [HttpPut("{id}")]
        public IActionResult RecuperaContaPorId(int id, [FromBody] UpdateContaDto contaDto)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return NotFound();
            }

            _mapper.Map(contaDto, conta);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaConta(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return NotFound();
            }

            _context.Remove(conta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
