using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Services
{
    public class ProfessoresService : IProfessoresService
    {
        public Task<Professor> AddProfessor(Professor model)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> AtualizaProfessor(int professorId, Professor model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarProfessor(int professorId)
        {
            throw new NotImplementedException();
        }

        public Task<Professor[]> ObterProfessoresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Professor> ObterProfessorPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
