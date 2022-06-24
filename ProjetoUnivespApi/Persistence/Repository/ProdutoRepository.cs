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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Produto> ObterProdutoPorId(int id)
        {
            IQueryable<Produto> query = _context.Produtos
               .Include(a => a.Id)
               .Include(a => a.Descricao)
               .Include(a => a.Quantidade)
               .Include(a => a.DataVenda);

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(a => a.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Produto[]> ObterProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(a => a.Id)
                .Include(a => a.Descricao)
                .Include(a => a.Quantidade)
                .Include(a => a.DataVenda);

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }
    }
}
