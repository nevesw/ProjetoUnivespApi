using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Context;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;

namespace ProjetoUnivespApi.Persistence.Repository
{
    public class AgendaAlunoRepository : IAgendaAlunoRepository
    {
        private readonly DataContext _context;

        public AgendaAlunoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AgendaAluno> CriaAulaAgendaAluno(AlunoInsertDto model, DateTime? dataAula)
        {
            try
            {
                var agendaAluno = new AgendaAluno()
                {
                    Data = dataAula,
                    DiaSemanaAulaAgendada = dataAula?.DayOfWeek.ToString()
                };

                
                _context.Add<AgendaAluno>(agendaAluno);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var agendaRetorno = await ObterAgendaAlunoPorId(agendaAluno.Id);
                    return agendaRetorno;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
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
