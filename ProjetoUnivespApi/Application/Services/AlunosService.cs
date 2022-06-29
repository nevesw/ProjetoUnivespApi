using AutoMapper;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Services
{
    public class AlunosService : IAlunosService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IAgendaAlunoRepository _agendaAlunoRepository;
        private readonly IMapper _mapper;

        public AlunosService(IGeralRepository geralRepository,
            IAlunoRepository alunoRepository,
            IProfessorRepository professorRepository,
            IAgendaAlunoRepository agendaAlunoRepository,
            IMapper mapper)
        {
            _geralRepository = geralRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _agendaAlunoRepository = agendaAlunoRepository;
            _mapper = mapper;
        }
        public async Task<AlunoDto> AddAluno(AlunoInsertDto model)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(model);

                var agendaAluno = InsereAulaAgendaAluno(model);

                aluno.AgendaAlunoId = agendaAluno?.Id;
                aluno.ProfessorId = model.ProfessorId;
                _geralRepository.Add<Aluno>(aluno);
                

                if (await _geralRepository.SaveChangesAsync())
                {
                    var alunoRetorno = await _alunoRepository.ObterAlunoPorId(aluno.Id);
                    return _mapper.Map<AlunoDto>(alunoRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AgendaAluno> InsereAulaAgendaAluno(AlunoInsertDto model)
        {
            try
            {
                var agendaAluno = new AgendaAluno()
                {
                    Data = model.DataAula,
                };

                _geralRepository.Add<AgendaAluno>(agendaAluno);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var agendaRetorno = await _agendaAlunoRepository.ObterAgendaAlunoPorId(agendaAluno.Id);
                    return _mapper.Map<AgendaAluno>(agendaRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<AlunoDto> AtualizaAluno(int alunoId, AlunoDto model)
        {
            try
            {
                var aluno = await _alunoRepository.ObterAlunoPorId(alunoId);
                if (aluno == null) return null;

                model.Id = aluno.Id;

                _mapper.Map(model, aluno);

                _geralRepository.Update<Aluno>(aluno);
                if (await _geralRepository.SaveChangesAsync())
                {
                    var alunoRetorno = await _alunoRepository.ObterAlunoPorId(aluno.Id);
                    return _mapper.Map<AlunoDto>(alunoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarAluno(int alunoId)
        {
            try
            {
                var aluno = await _alunoRepository.ObterAlunoPorId(alunoId);
                if (aluno == null) throw new Exception("Aluno não foi encontrado");

                _geralRepository.Delete<Aluno>(aluno);
                return await _geralRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AlunoDto> ObterAlunoPorId(int id)
        {
            try
            {
                var aluno = await _alunoRepository.ObterAlunoPorId(id);
                if (aluno == null) return null;

                var resultado = _mapper.Map<AlunoDto>(aluno);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<AlunoDto[]> ObterAlunosAsync()
        {
            try
            {
                var alunos = await _alunoRepository.ObterAlunosAsync();
                if (alunos == null) return null;

                var resultado = _mapper.Map<AlunoDto[]>(alunos);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
