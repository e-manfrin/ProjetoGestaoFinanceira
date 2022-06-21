using AutoMapper;
using FluentResults;
using GestaoFinanceira.Data;
using GestaoFinanceira.Data.Dtos.Conta;
using GestaoFinanceira.Models;

namespace GestaoFinanceira.Services
{
    public class ContaService
    {
        private AppDbContext _context;
        private IMapper _mapper;


        public ContaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadContaDto AdicionaConta(CreateContaDto contaDto)
        {
            Conta conta = _mapper.Map<Conta>(contaDto);
            _context.Contas.Add(conta);
            _context.SaveChanges();
            return _mapper.Map<ReadContaDto>(conta);
        }

        public List<ReadContaDto> RecuperarConta(string nomeDaConta)
        {
            List<Conta> contas = _context.Contas.ToList();
            if (contas == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadContaDto>>(contas);
        }

        public ReadContaDto RecuperarContaPorId(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return null;
            }
            return _mapper.Map<ReadContaDto>(conta);
        }

        public ReadContaDto RecuperaContaPorId(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta != null)
            {
                return _mapper.Map<ReadContaDto>(conta);
            }
            return null;
        }

        public Result RecuperaContaPorId(int id, UpdateContaDto contaDto)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return Result.Fail("Conta não encontrado");
            }
            _mapper.Map(contaDto, conta);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaConta(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return Result.Fail("Conta não encontrado");
            }

            _context.Remove(conta);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}