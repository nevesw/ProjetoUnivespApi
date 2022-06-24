using ProjetoUnivespApi.Application.Dtos;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface IAlunosService
    {
        Task<AlunoDto> AddAluno(AlunoInsertDto model);
        Task<AlunoDto> AtualizaAluno(int alunoId, AlunoDto model);
        Task<bool> DeletarAluno(int alunoId);
        Task<AlunoDto[]> ObterAlunosAsync();
        Task<AlunoDto> ObterAlunoPorId(int id);
    }
}

