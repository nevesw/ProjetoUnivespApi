using AutoMapper;
using Moq;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Helpers;
using ProjetoUnivespApi.Application.Services;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.ProjetoUnivespApi.Application.Services
{
    public class PedidosServiceTests
    {
        private readonly PedidosService _pedidoService;
        private readonly Mock<IPedidoRepository> _pedidoRepoMock = new Mock<IPedidoRepository>();
        private readonly Mock<IGeralRepository> _geralRepoMock = new Mock<IGeralRepository>();
        private readonly IMapper _mapper;

        public PedidosServiceTests()
        {
            var profile = new ProjetoIntegradorProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _pedidoService = new PedidosService(_geralRepoMock.Object,_pedidoRepoMock.Object,_mapper);

        }

        [Fact]
        public async Task AddPedido_DeveAdicionarUmPedido()
        {
            // Arrange
           
            var insert = new PedidoInsertDto()
            {
                Id = 1,
                produtoId = 1,
                alunoId = 1,
                Meses = 1,
                pagamentoId = 1,
                Plano = "Premium"
            };

            var pedidoDto = new PedidoDto
            {
                Id = 1,
                produtoId = insert.produtoId,
                alunoId = insert.alunoId,
                Meses = insert.Meses,
                pagamentoId = insert.pagamentoId,
                Plano = insert.Plano,
            };

            var pedido = new Pedido
            {
                Id = 1,
                ProdutoId = insert.produtoId,
                AlunoId = insert.alunoId,
                Quantidade = insert.Meses,
                PagamentoId = insert.pagamentoId,
                Descricao = insert.Plano,
            };

            _geralRepoMock.Setup(x => x.Add(pedidoDto));
            _geralRepoMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true);
            _pedidoRepoMock.Setup(x => x.ObterPedidoPorId(pedidoDto.Id)).ReturnsAsync(pedido);

            // Act
            var result = await _pedidoService.AddPedido(insert);

            // Assert
            Assert.NotNull(result);
        }

    }
}
