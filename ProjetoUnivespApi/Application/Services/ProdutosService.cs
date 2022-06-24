using AutoMapper;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Services
{
    public class ProdutosService : IProdutosService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutosService(IGeralRepository geralRepository,
            IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _geralRepository = geralRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> AddProduto(ProdutoInsertDto model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);

                _geralRepository.Add<Produto>(produto);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var produtoRetorno = await _produtoRepository.ObterProdutoPorId(produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
           
        }

        public async Task<ProdutoDto> AtualizaProduto(int produtoId, ProdutoDto model)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorId(produtoId);
                if (produto == null) return null;

                model.Id = produto.Id;

                _mapper.Map(model, produto);

                _geralRepository.Update<Produto>(produto);
                if (await _geralRepository.SaveChangesAsync())
                {
                    var produtoRetorno = await _produtoRepository.ObterProdutoPorId(produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeletarProduto(int produtoId)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorId(produtoId);
                if (produto == null) throw new Exception("Produto não foi encontrado");

                _geralRepository.Delete<Produto>(produto);
                return await _geralRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> ObterProdutoPorId(int id)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorId(id);
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto>(produto);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto[]> ObterProdutosAsync()
        {
            try
            {
                var produtos = await _produtoRepository.ObterProdutosAsync();
                if (produtos == null) return null;

                var resultado = _mapper.Map<ProdutoDto[]>(produtos);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
