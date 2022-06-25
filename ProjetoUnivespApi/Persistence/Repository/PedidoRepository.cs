using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Context;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext _context;

        public PedidoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Pedido> ObterPedidoPorId(int id)
        {
            IQueryable<Pedido> query = _context.Pedidos
               .Include(a => a.codPedido)
               .Include(a => a.Descricao)
               .Include(a => a.Quantidade)
               .Include(a => a.DataPedido)
               .Include(a => a.PagamentoId)
               .Include(a => a.AlunoId)
               .Include(a => a.ProdutoId);

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(a => a.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Pedido[]> ObterPedidosAsync()
        {
            IQueryable<Pedido> query = _context.Pedidos
               .Include(a => a.codPedido)
               .Include(a => a.Descricao)
               .Include(a => a.Quantidade)
               .Include(a => a.DataPedido)
               .Include(a => a.PagamentoId)
               .Include(a => a.AlunoId)
               .Include(a => a.ProdutoId);

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Pedido[]> ObterPedidosPorAluno(int alunoId)
        {

            IQueryable<Pedido> query = _context.Pedidos
                .Include(a => a.Id)
                .Include(a => a.Descricao)
                .Include(a => a.Quantidade)
                .Include(a => a.DataPedido);

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(a => a.AlunoId == alunoId);

            return await query.AsNoTracking().ToArrayAsync();
        }
    }
}
