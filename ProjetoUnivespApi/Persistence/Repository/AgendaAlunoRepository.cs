using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Context;
using ProjetoUnivespApi.Persistence.Interfaces;

namespace ProjetoUnivespApi.Persistence.Repository
{
    public class AgendaAlunoRepository : IAgendaAlunoRepository
    {
        private readonly DataContext _context;

        public AgendaAlunoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AgendaAluno> ObterAgendaAlunoPorId(int id)
        {
            IQueryable<AgendaAluno> query = _context.AgendaAlunos;

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(a => a.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<AgendaAluno[]> ObterAgendaAlunosAsync()
        {
            IQueryable<AgendaAluno> query = _context.AgendaAlunos;

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

    }
}
