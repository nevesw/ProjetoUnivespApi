using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Context;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Aluno> ObterAlunoPorId(int id)
        {
            IQueryable<Aluno> query = _context.Alunos
               .Include(a => a.Endereco)
               .Include(a => a.AgendaAluno)
               .Include(a => a.Professor)
               .Include(a => a.AgendaAluno);

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(a => a.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> ObterAlunosAsync()
        {
            IQueryable<Aluno> query = _context.Alunos
                .Include(a => a.Endereco)
                .Include(a => a.AgendaAluno)
                .Include(a => a.Professor)
                .Include(a => a.AgendaAluno);

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

    }
}
