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
    [Route("api/pedido")]
    public class PedidoController : Controller
    {       

        private readonly IPedidosService _pedidosService;

        public PedidoController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet]
        [Route("lista_pedidos")]
        [Authorize(Roles = "funcionario,externo")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _pedidosService.ObterPedidosAsync();
                if (pedidos == null) return NotFound("Nenhum pedido encontrado.");

                return Ok(pedidos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("busca_pedido/{id}")]
        [Authorize(Roles = "funcionario,externo")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pedido = await _pedidosService.ObterPedidoPorId(id);
                if (pedido == null) return NotFound("Pedido não encontrado.");


                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedido. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("busca_pedido/aluno/{id}")]
        [Authorize(Roles = "funcionario,externo")]
        public async Task<IActionResult> GetPedidosPorAluno(int alunoId)
        {
            try
            {
                var pedidos = await _pedidosService.ObterPedidosPorAluno(alunoId);
                if (pedidos == null) return NotFound("Pedido não encontrado.");


                return Ok(pedidos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedido. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("cadastro_pedido")]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Post(PedidoInsertDto modelPedido)
        {
            try
            {

                var pedido = await _pedidosService.AddPedido(modelPedido);


                if (pedido == null) return BadRequest("Erro ao tentar adicionar pedido.");

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar pedido. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("editar_pedido")]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Put(PedidoDto modelPedido)
        {
            try
            {
                var pedido = await _pedidosService.AtualizaPedido(modelPedido.Id, modelPedido);
                if (pedido == null) return BadRequest("Erro ao tentar atualizar pedido.");

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar pedido. Erro: {ex.Message}");
            }

        }

        [HttpDelete]
        [Route("deletar_pedido/{id}")]
        [Authorize(Roles = "funcionario")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _pedidosService.DeletarPedido(id) ?
                   Ok(new { message = "Pedido deletado com sucesso." }) :
                   BadRequest("Não foi possivel deletar pedido.");
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar pedido. Erro: {ex.Message}");
            }

        }
    }
}
