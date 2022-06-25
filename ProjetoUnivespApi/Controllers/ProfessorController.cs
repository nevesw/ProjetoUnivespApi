using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        [Route("lista_professores")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Professor>>> Get([FromServices] DataContext context)
        {
            var professores = context.Professores.AsQueryable();

            return professores.ToList();
        }

        [HttpGet]
        [Route("busca_professor/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Professor>>> Get([FromServices] DataContext context, int id)
        {
            var professor = context.Professores.Find(id);

            return Ok(professor);
        }

        [HttpPost]
        [Route("cadastro_professor")]
        [AllowAnonymous]
        public async Task<ActionResult<Professor>> Post([FromServices] DataContext context,
             [FromBody] Professor modelProfessor)
        {
            if (ModelState.IsValid)
            {
                modelProfessor.DataCriacao = DateTime.UtcNow.ToUniversalTime();
                context.Professores.Add(modelProfessor);
                await context.SaveChangesAsync();
                return Ok(new
                {
                    StatusCode = 200,
                    Messsage = "Professor cadastrado com sucesso"
                });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("editar_professor")]
        [AllowAnonymous]
        public async Task<ActionResult<Professor>> Put([FromServices] DataContext context,
            [FromBody] Professor modelProfessor)
        {
            if (ModelState.IsValid)
            {
                var aluno = context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == modelProfessor.Id);
                if (aluno == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Professor não encontrado"
                    });
                }
                else
                {
                    context.Entry(modelProfessor).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Professor atualizado com sucesso"
                    });
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("deletar_professor/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Aluno>> Delete([FromServices] DataContext context,
            int id)
        {
            var aluno = context.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Professor não encontrado"
                });
            }
            else
            {
                context.Remove(aluno);
                context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Professor excluido com sucesso"
                });
            }
        }
    }
}
