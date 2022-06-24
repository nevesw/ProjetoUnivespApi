using ProjetoUnivespApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface IPedidosService
    {
        Task<PedidoDto> AddPedido(PedidoInsertDto model);
        Task<PedidoDto> AtualizaPedido(int pedidoId, PedidoDto model);
        Task<bool> DeletarPedido(int pedidoId);
        Task<PedidoDto[]> ObterPedidosAsync();
        Task<PedidoDto> ObterPedidoPorId(int pedidoId);
        Task<PedidoDto[]> ObterPedidosPorAluno(int alunoId);
    }
}
