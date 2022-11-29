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
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string usuario, string senha)
        {
            IQueryable<User> query = _context.Users.Where(x => x.Usuario == usuario
            && x.Senha == senha && x.Tipo != "externo");

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetExternalUser(string usuario, string senha)
        {
            IQueryable<User> query = _context.Users.Where(x => x.Usuario == usuario
            && x.Senha == senha && x.Tipo == "externo");

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
