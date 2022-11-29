using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User model);

        Task<User> GetUser(string usuario, string senha);

        Task<User> GetExternalUser(string usuario, string senha);
    }
}
