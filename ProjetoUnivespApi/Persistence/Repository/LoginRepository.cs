using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Context;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;

        public LoginRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Login> GetUser(string usuario, string senha)
        {
            IQueryable<Login> query = _context.Logins.Where(x => x.Usuario == usuario
            && x.Senha == senha);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
