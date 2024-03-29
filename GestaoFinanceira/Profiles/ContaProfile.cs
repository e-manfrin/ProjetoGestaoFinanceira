﻿using AutoMapper;
using GestaoFinanceira.Data.Dtos.Conta;
using GestaoFinanceira.Models;

namespace GestaoFinanceira.Profiles
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<CreateContaDto, Conta>();
            CreateMap<Conta, ReadContaDto>();
            CreateMap<UpdateContaDto, Conta>();
        }
    }
}
