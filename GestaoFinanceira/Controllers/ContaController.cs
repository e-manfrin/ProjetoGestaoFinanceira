using AutoMapper;
using FluentResults;
using GestaoFinanceira.Models;
using GestaoFinanceira.Data.Dtos.Conta;
using GestaoFinanceira.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GestaoFinanceira.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private ContaService _contaService;

        public ContaController(ContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost]
        public IActionResult AdicionaConta([FromBody] CreateContaDto contaDto)
        {
            ReadContaDto readDto = _contaService.AdicionaConta(contaDto);
            return CreatedAtAction(nameof(RecuperaContaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarConta([FromQuery] string nomeDaConta)
        {
            List<ReadContaDto> readDto = _contaService.RecuperarConta(nomeDaConta);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarContaPorId(int id)
        {
            ReadContaDto readDto = _contaService.RecuperarContaPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult RecuperaContaPorId(int id, [FromBody] UpdateContaDto contaDto)
        {
            Result resultado = _contaService.RecuperaContaPorId(id, contaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaConta(int id)
        {
            Result resultado = _contaService.DeletaConta(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}