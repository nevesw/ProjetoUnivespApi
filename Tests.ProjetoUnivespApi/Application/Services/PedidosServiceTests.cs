using AutoMapper;
using Moq;
using ProjetoUnivespApi.Application.Services;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.ProjetoUnivespApi.Application.Services
{
    public class PedidosServiceTests
    {
        private readonly PedidosService _pedidoService;
        private readonly Mock<IPedidoRepository> _pedidoRepoMock = new Mock<IPedidoRepository>();
        private readonly Mock<IGeralRepository> _geralRepoMock = new Mock<IGeralRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public PedidosServiceTests()
        {
           // _pedidoService = new PedidosService(_geralRepoMock,_pedidoService,_mapperMock);

        }

        [Fact]
        public async Task AddPedido_DeveAdicionarUmPedido()
        {
            // Arrange


            // Act

            // Assert
        }

    }
}
