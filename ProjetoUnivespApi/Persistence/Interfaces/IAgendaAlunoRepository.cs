using ProjetoUnivespApi.Domain.Entities;

namespace ProjetoUnivespApi.Persistence.Interfaces
{
    public interface IAgendaAlunoRepository
    {
        Task<AgendaAluno[]> ObterAgendaAlunosAsync();
        Task<AgendaAluno> ObterAgendaAlunoPorId(int id);
    }
}
