using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto[]> ObterProdutosAsync();
        Task<Produto> ObterProdutoPorId(int id);
    }
}
