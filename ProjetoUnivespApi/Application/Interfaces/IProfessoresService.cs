using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface IProfessoresService
    {
        Task<Professor> AddProfessor(Professor model);
        Task<Professor> AtualizaProfessor(int professorId, Professor model);
        Task<bool> DeletarProfessor(int professorId);
        Task<Professor[]> ObterProfessoresAsync();
        Task<Professor> ObterProfessorPorId(int id);
    }
}
