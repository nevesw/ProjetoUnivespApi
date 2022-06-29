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
        private readonly IAgendaAlunoService _agendaAlunoService;
        private readonly IProfessorRepository _professorRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunosService(IGeralRepository geralRepository,
            IAgendaAlunoService agendaAlunoService,
            IProfessorRepository professorRepository,
            IAlunoRepository alunoRepository,
            IMapper mapper)
        {
            _geralRepository = geralRepository;
            _agendaAlunoService = agendaAlunoService;
            _professorRepository = professorRepository;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }
        public async Task<AlunoDto> AddAluno(AlunoInsertDto model)
        {
            try
            {        

                var agendaAluno =  await _agendaAlunoService.AddAulaAgendaAluno(model, model.DataAula);

                var aluno = _mapper.Map<Aluno>(model);

                aluno.AgendaAlunoId = agendaAluno?.Id;

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
