using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence;
using ProjetoUnivespApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Controllers
{
    [ApiController]
    [Route("api/professor")]
    public class ProfessorController : Controller
    {
        private readonly IProfessoresService _professoresService;

        public ProfessorController(IProfessoresService professoresService)
        {
            _professoresService = professoresService;
        }

        [HttpGet]
        [Route("lista_professores")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var professores = await _professoresService.ObterProfessoresAsync();
                if (professores == null) return NotFound("Nenhum professor encontrado.");

                return Ok(professores);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar professores. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("busca_professor/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var professor = await _professoresService.ObterProfessorPorId(id);
                if (professor == null) return NotFound("Professor não encontrado.");


                return Ok(professor);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar professor. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("cadastro_professor")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(ProfessorInsertDto modelProfessor)
        {

            try
            {
                modelProfessor.DataCriacao = DateTime.UtcNow.ToUniversalTime();
                var professor = await _professoresService.AddProfessor(modelProfessor);
                if (professor == null) return BadRequest("Erro ao tentar adicionar professor.");

                return Ok(professor);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar professor. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("editar_professor")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(ProfessorDto modelProfessor)
        {
            try
            {
                var professor = await _professoresService.AtualizaProfessor(modelProfessor.Id, modelProfessor);
                if (professor == null) return BadRequest("Erro ao tentar atualizar professor.");

                return Ok(professor);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar professor. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deletar_professor/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _professoresService.DeletarProfessor(id) ?
                   Ok(new { message = "Professor deletado com sucesso." }) :
                   BadRequest("Não foi possivel deletar professor.");
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar professor. Erro: {ex.Message}");
            }
        }
    }
}
