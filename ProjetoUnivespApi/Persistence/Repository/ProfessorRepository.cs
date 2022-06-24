using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Context;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly DataContext _context;

        public ProfessorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Professor[]> ObterProfessoresAsync()
        {
            IQueryable<Professor> query = _context.Professores
              .Include(p => p.AgendaProfessor)
              .Include(p => p.Alunos);
            
            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Professor> ObterProfessorPorId(int id)
        {
            IQueryable<Professor> query = _context.Professores
              .Include(p => p.AgendaProfessor)
              .Include(p => p.Alunos);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Professor> ObterProfessorPorNome(string nome)
        {
            IQueryable<Professor> query = _context.Professores
              .Include(p => p.AgendaProfessor)
              .Include(p => p.Alunos);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Nome == nome);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
