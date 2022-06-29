using AutoMapper;
using Moq;
using ProjetoUnivespApi.Application.Dtos;
using ProjetoUnivespApi.Application.Helpers;
using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Application.Services;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests.ProjetoUnivespApi.Application.Services
{
    public class AlunosServiceTests
    {
        private readonly AlunosService _alunosService;
        private readonly Mock<IAlunoRepository> _alunoRepositoryMock = new Mock<IAlunoRepository>();
        private readonly Mock<IAgendaAlunoService> _agendaAlunoService = new Mock<IAgendaAlunoService>();
        private readonly Mock<IProfessorRepository> _professorRepositoryMock = new Mock<IProfessorRepository>();
        private readonly Mock<IGeralRepository> _geralRepositoryMock = new Mock<IGeralRepository>();
        private readonly IMapper _mapper;

        public AlunosServiceTests()
        {
            var profile = new ProjetoIntegradorProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _alunosService = new AlunosService(_geralRepositoryMock.Object,
                _agendaAlunoService.Object,
                _professorRepositoryMock.Object,
                 _alunoRepositoryMock.Object,
                _mapper);
        }

        [Fact]
        public async Task AddAluno_DeveAdicionarUmAluno()
        {
            // Arrange

            var insert = new AlunoInsertDto()
            {
                Id = 1,
                Nome = "Marcelo",
                NumeroCelular = "(81)98755-7343",
                ProfessorId = 1,
                Cpf = "801.223.910-80",
                StatusPagamento = "Pago",
                DataAula = new DateTime(2022, 11, 30),
            };

            var professorDoAluno = new Professor()
            {
                Id = 1,
                Nome = "Claudio",
                AgendaProfessor = new AgendaProfessor
                {
                    DataAgendada = new DateTime(2022,10,20)
                }
            };

            var alunoDto = new AlunoDto
            {
                Id = 1,
                Nome = "Marcelo",
                NumeroCelular = "(81)98755-7343",
                ProfessorId = 1,
                Cpf = "801.223.910-80",
                StatusPagamento = "Pago",

            };

            var aluno = new Aluno
            {
                Id = 1,
                Nome = "Marcelo",
                NumeroCelular = "(81)98755-7343",
                ProfessorId = 1,
                Cpf = "801.223.910-80",
                StatusPagamento = "Pago",
                AgendaAluno = new AgendaAluno
                {
                    Id = 1,
                    Data = new DateTime(2022, 11, 30),
                },
            };

            _geralRepositoryMock.Setup(x => x.Add(alunoDto));
            _geralRepositoryMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true);
            _alunoRepositoryMock.Setup(x => x.ObterAlunoPorId(alunoDto.Id)).ReturnsAsync(aluno);
            _professorRepositoryMock.Setup(x => x.ObterProfessorPorId(alunoDto.ProfessorId)).ReturnsAsync(professorDoAluno);
            // Act
            var result = await _alunosService.AddAluno(insert);

            // Assert
            Assert.NotNull(result);
        }
    }
}
