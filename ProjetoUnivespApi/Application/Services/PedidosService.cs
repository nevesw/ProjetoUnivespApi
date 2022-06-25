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
    public class PedidosService : IPedidosService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidosService(IGeralRepository geralRepository,
            IPedidoRepository pedidoRepository,
            IMapper mapper)
        {
            _geralRepository = geralRepository;
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<PedidoDto> AddPedido(PedidoInsertDto model)
        {
            try
            {            

                var pedido = _mapper.Map<Pedido>(model);
                pedido.codPedido = Guid.NewGuid().ToString();

                _geralRepository.Add<Pedido>(pedido);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var pedidoRetorno = await _pedidoRepository.ObterPedidoPorId(pedido.Id);
                    return _mapper.Map<PedidoDto>(pedidoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public Task<PedidoDto> AtualizaPedido(int pedidoId, PedidoDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarPedido(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public async Task<PedidoDto[]> ObterPedidosPorAluno(int alunoId)
        {
            try
            {
                var pedidos = await _pedidoRepository.ObterPedidosPorAluno(alunoId);
                if (pedidos == null) return null;

                var resultado = _mapper.Map<PedidoDto[]>(pedidos);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> ObterPedidoPorId(int pedidoId)
        {
            try
            {
                var pedido = await _pedidoRepository.ObterPedidoPorId(pedidoId);
                if (pedido == null) return null;

                var resultado = _mapper.Map<PedidoDto>(pedido);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto[]> ObterPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoRepository.ObterPedidosAsync();
                if (pedidos == null) return null;

                var resultado = _mapper.Map<PedidoDto[]>(pedidos);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
