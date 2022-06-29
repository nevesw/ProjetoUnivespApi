using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Domain.Entities;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface IAgendaAlunoService
    {
        Task<AgendaAluno> AddAulaAgendaAluno(AlunoInsertDto model, DateTime? dataAula);
        Task<AgendaAluno> ObterAgendaAlunoPorId(int id);
    }
}
