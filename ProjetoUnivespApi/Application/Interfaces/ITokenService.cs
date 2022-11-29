using ProjetoUnivespApi.Domain.Entities;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);

        Task<string> GenerateTokenForExternalUsers(User user);

    }
}
