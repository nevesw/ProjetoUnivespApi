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
    public class ProfessoresService : IProfessoresService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;

        public ProfessoresService(IGeralRepository geralRepository,
            IProfessorRepository professorRepository,
            IMapper mapper)
        {
            _geralRepository = geralRepository;
            _professorRepository = professorRepository;
            _mapper = mapper;
        }
        public async Task<ProfessorDto> AddProfessor(ProfessorInsertDto model)
        {
            try
            {
                var professor = _mapper.Map<Professor>(model);
               

                _geralRepository.Add<Professor>(professor);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var professorRetorno = await _professorRepository.ObterProfessorPorId(professor.Id);
                    var resultado = _mapper.Map<ProfessorDto>(professorRetorno);
                    return resultado;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            
        }

        public async Task<ProfessorDto> AtualizaProfessor(int professorId, ProfessorDto model)
        {
            try
            {
                var professor = await _professorRepository.ObterProfessorPorId(professorId);
                if (professor == null) return null;

                model.Id = professor.Id;

                _mapper.Map(model, professor);

                _geralRepository.Update<Professor>(professor);
                if (await _geralRepository.SaveChangesAsync())
                {
                    var professorRetorno = await _professorRepository.ObterProfessorPorId(professor.Id);
                    return _mapper.Map<ProfessorDto>(professorRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarProfessor(int professorId)
        {
            try
            {
                var professor = await _professorRepository.ObterProfessorPorId(professorId);
                if (professor == null) throw new Exception("Professor não foi encontrado");

                _geralRepository.Delete<Professor>(professor);
                return await _geralRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessorDto[]> ObterProfessoresAsync()
        {
            try
            {
                var professor = await _professorRepository.ObterProfessoresAsync();
                if (professor == null) return null;

                var resultado = _mapper.Map<ProfessorDto[]>(professor);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessorDto> ObterProfessorPorId(int professorId)
        {
            try
            {
                var professor = await _professorRepository.ObterProfessorPorId(professorId);
                if (professor == null) return null;

                var resultado = _mapper.Map<ProfessorDto>(professor);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
