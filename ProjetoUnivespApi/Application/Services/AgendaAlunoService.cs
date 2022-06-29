using AutoMapper;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Interfaces;

namespace ProjetoUnivespApi.Application.Services
{
    public class AgendaAlunoService : IAgendaAlunoService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IAgendaAlunoRepository _agendaAlunoRepository;
        private readonly IMapper _mapper;

        public AgendaAlunoService(IGeralRepository geralRepository,
            IAgendaAlunoRepository agendaAlunoRepository,
            IMapper mapper)
        {
            _agendaAlunoRepository = agendaAlunoRepository;
            _geralRepository = geralRepository;
            _mapper = mapper;
        }

        public async Task<AgendaAluno> AddAulaAgendaAluno(AlunoInsertDto model, DateTime? dataAula)
        {
            try
            {
                var agendaAluno = new AgendaAluno()
                {
                    Data = dataAula,
                    DiaSemanaAulaAgendada = dataAula?.DayOfWeek.ToString()
                };


                _geralRepository.Add<AgendaAluno>(agendaAluno);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var agendaAlunoRetorno = await _agendaAlunoRepository.ObterAgendaAlunoPorId(agendaAluno.Id);
                    var resultado = _mapper.Map<AgendaAluno>(agendaAlunoRetorno);
                    return resultado;
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
            return await _agendaAlunoRepository.ObterAgendaAlunoPorId(id);
        }
    }
}
