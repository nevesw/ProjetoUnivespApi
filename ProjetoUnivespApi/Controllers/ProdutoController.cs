using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutosService _produtosService;

        public ProdutoController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet]
        [Route("lista_produtos")]
        [Authorize(Roles = "funcionario,externo")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _produtosService.ObterProdutosAsync();
                if (produtos == null) return NotFound("Nenhum produto encontrado.");

                return Ok(produtos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("busca_produto/{id}")]
        [Authorize(Roles = "funcionario,externo")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var produto = await _produtosService.ObterProdutoPorId(id);
                if (produto == null) return NotFound("Produto não encontrado.");


                return Ok(produto);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar produto. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("cadastro_produto")]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Post(ProdutoInsertDto modelProduto)
        {
            try
            {

                var produto = await _produtosService.AddProduto(modelProduto);
                

                if (produto == null) return BadRequest("Erro ao tentar adicionar produto.");

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar produto. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("editar_produto")]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Put(ProdutoDto modelProduto)
        {
            try
            {
                var produto = await _produtosService.AtualizaProduto(modelProduto.Id, modelProduto);
                if (produto == null) return BadRequest("Erro ao tentar atualizar produto.");

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar produto. Erro: {ex.Message}");
            }

        }

        [HttpDelete]
        [Route("deletar_produto/{id}")]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _produtosService.DeletarProduto(id) ?
                   Ok(new { message = "Produto deletado com sucesso." }) :
                   BadRequest("Não foi possivel deletar produto.");
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar produto. Erro: {ex.Message}");
            }

        }
    }
}
