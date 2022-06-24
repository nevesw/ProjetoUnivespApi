using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly ILoginRepository _loginRepository;


        public LoginService(IGeralRepository geralRepository,
            ILoginRepository loginRepository
)
        {
            _geralRepository = geralRepository;
            _loginRepository = loginRepository;
        }
        public  async Task<Login> AddUser(Login model)
        {
            try
            {
              
                _geralRepository.Add<Login>(model);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var loginRetorno = await _loginRepository.GetUser(model.Usuario, model.Senha);
                    return loginRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Login> GetUser(string usuario, string senha)
        {
            try
            {
                var user = await _loginRepository.GetUser(usuario, senha);

                if (user != null)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
