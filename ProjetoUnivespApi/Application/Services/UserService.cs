using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using ProjetoUnivespApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IUserRepository _userRepository;


        public UserService(IGeralRepository geralRepository,
            IUserRepository userRepository
)
        {
            _geralRepository = geralRepository;
            _userRepository = userRepository;
        }
        public  async Task<User> AddUser(User model)
        {
            try
            {
              
                _geralRepository.Add<User>(model);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var loginRetorno = await _userRepository.GetUser(model.Usuario, model.Senha);
                    return loginRetorno;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUser(string usuario, string senha)
        {
            try
            {
                var user = await _userRepository.GetUser(usuario, senha);

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

        public async Task<User> GetExternalUser(string usuario, string senha)
        {
            try
            {
                var externalUser = await _userRepository.GetExternalUser(usuario, senha);

                if (externalUser != null)
                {
                    return externalUser;
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
