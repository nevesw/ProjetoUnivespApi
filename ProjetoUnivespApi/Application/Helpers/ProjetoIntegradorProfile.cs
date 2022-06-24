﻿using AutoMapper;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Helpers
{
    public class ProjetoIntegradorProfile : Profile
    {
        public ProjetoIntegradorProfile()
        {
            CreateMap<Aluno, AlunoDto>().ReverseMap();
            CreateMap<Aluno, AlunoInsertDto>().ReverseMap();
        }
    }
}