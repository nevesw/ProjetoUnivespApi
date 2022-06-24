using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido[]> ObterPedidosAsync();
        Task<Pedido> ObterPedidoPorId(int id);
        Task<Pedido[]> ObterPedidosPorAluno(int alunoId);
    }
}
