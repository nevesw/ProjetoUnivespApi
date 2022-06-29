using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Domain.Entities;

namespace ProjetoUnivespApi.Persistence.Interfaces
{
    public interface IAgendaAlunoRepository
    {
        Task<AgendaAluno> CriaAulaAgendaAluno(AlunoInsertDto model, DateTime? dataAula);
        Task<AgendaAluno[]> ObterAgendaAlunosAsync();
        Task<AgendaAluno> ObterAgendaAlunoPorId(int id);
    }
}
