using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Interfaces
{
    public interface IProfessorRepository
    {
        Task<Professor[]> ObterProfessoresAsync();
        Task<Professor> ObterProfessorPorId(int id);

        Task<Professor> ObterProfessorPorNome(string Nome);
    }
}
