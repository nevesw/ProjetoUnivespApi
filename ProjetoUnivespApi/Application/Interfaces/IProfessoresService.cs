using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface IProfessoresService
    {
        Task<ProfessorDto> AddProfessor(ProfessorInsertDto model);
        Task<ProfessorDto> AtualizaProfessor(int professorId, ProfessorDto model);
        Task<bool> DeletarProfessor(int professorId);
        Task<ProfessorDto[]> ObterProfessoresAsync();
        Task<ProfessorDto> ObterProfessorPorId(int professorId);
    }
}
