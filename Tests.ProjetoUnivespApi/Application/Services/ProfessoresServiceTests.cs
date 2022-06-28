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
using System.Threading.Tasks;
using Xunit;

namespace Tests.ProjetoUnivespApi.Application.Services
{
    public class ProfessoresServiceTests
    {
        private readonly ProfessoresService _professoresService;
        private readonly Mock<IProfessorRepository> _professorRepositoryMock = new Mock<IProfessorRepository>();
        private readonly Mock<IGeralRepository> _geralRepositoryMock = new Mock<IGeralRepository>();
        private readonly IMapper _mapper;

        public ProfessoresServiceTests()
        {
            var profile = new ProjetoIntegradorProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _professoresService = new ProfessoresService(_geralRepositoryMock.Object, _professorRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task AddProfessor_DeveAdicionarUmProfessor()
        {
            // Arrange

            var insert = new ProfessorInsertDto()
            {
                Id = 1,
                Nome = "Claudio",
                NumeroCelular = "99999-8888",
                Email = "claudioprof@gmail.com",
                Status = "Ativo",
                Cnpj = "59.639.379/0001-27",
                UsuarioPlataforma = "cluser451",
                DataCriacao = new DateTime(2021,11,28),

            };

            var professorDto = new ProfessorDto
            {
                Id = 1,
                Nome = "Claudio",
                NumeroCelular = "99999-8888",
                Email = "claudioprof@gmail.com",
                Status = "Ativo",
                Cnpj = "59.639.379/0001-27",
                UsuarioPlataforma = "cluser451",
                DataCriacao = new DateTime(2021, 11, 28),
            };

            var professor = new Professor
            {
                Id = 1,
                Nome = "Claudio",
                NumeroCelular = "99999-8888",
                Email = "claudioprof@gmail.com",
                Status = "Ativo",
                Cnpj = "59.639.379/0001-27",
                UsuarioPlataforma = "cluser451",
                DataCriacao = new DateTime(2021, 11, 28),
            };

            _geralRepositoryMock.Setup(x => x.Add(professorDto));
            _geralRepositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true);
            _professorRepositoryMock.Setup(x => x.ObterProfessorPorId(professorDto.Id)).ReturnsAsync(professor);

            // Act
            var result = await _professoresService.AddProfessor(insert);

            // Assert
            Assert.NotNull(result);
        }
    }
}
