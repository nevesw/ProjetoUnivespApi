using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Interfaces
{
    public interface ILoginService
    {
        Task<Login> AddUser(Login model);

        Task<Login> GetUser(string usuario, string senha);
    }
}
