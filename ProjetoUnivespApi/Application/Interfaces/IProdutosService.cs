using ProjetoUnivespApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface IProdutosService
    {
        Task<ProdutoDto> AddProduto(ProdutoInsertDto model);
        Task<ProdutoDto> AtualizaProduto(int produtoId, ProdutoDto model);
        Task<bool> DeletarProduto(int produtoId);
        Task<ProdutoDto[]> ObterProdutosAsync();
        Task<ProdutoDto> ObterProdutoPorId(int id);
    }
}
