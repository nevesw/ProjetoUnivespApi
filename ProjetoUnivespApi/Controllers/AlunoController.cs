using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Interfaces;

namespace ProjetoUnivespApi.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : Controller
    {
        private readonly IAlunosService _alunosService;

        public AlunoController(IAlunosService alunosService)
        {
            _alunosService = alunosService;
        }

        [HttpGet]
        [Route("lista_alunos")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var alunos = await _alunosService.ObterAlunosAsync();
                if (alunos == null) return NotFound("Nenhum aluno encontrado.");

                return Ok(alunos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar alunos. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("busca_aluno/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var aluno = await _alunosService.ObterAlunoPorId(id);
                if (aluno == null) return NotFound("Aluno não encontrado.");


                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar aluno. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("cadastro_aluno")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(AlunoInsertDto modelAluno)
        {
            try
            {

                var aluno = await _alunosService.AddAluno(modelAluno);
                if (aluno.ProfessorId == 0) return this.StatusCode(StatusCodes.Status400BadRequest, "erro prof");

                if (aluno == null) return BadRequest("Erro ao tentar adicionar aluno.");

                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar aluno. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("editar_aluno")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(AlunoDto modelAluno)
        {
            try
            {
                var aluno = await _alunosService.AtualizaAluno(modelAluno.Id, modelAluno);
                if (aluno == null) return BadRequest("Erro ao tentar atualizar aluno.");

                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar aluno. Erro: {ex.Message}");
            }

        }

        [HttpDelete]
        [Route("deletar_aluno/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _alunosService.DeletarAluno(id) ?
                   Ok(new { message = "Aluno deletado com sucesso." }) :
                   BadRequest("Não foi possivel deletar aluno.");
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar aluno. Erro: {ex.Message}");
            }

        }
    }
}
