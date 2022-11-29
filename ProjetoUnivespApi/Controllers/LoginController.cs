using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUnivespApi.Application.Interfaces;
using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("acesso_usuario")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string usuario, string senha)
        {
            try
            {
                var user = await _userService.GetUser(usuario, senha);
                if (user == null) return BadRequest("Erro ao tentar recuperar usuario.");

                var acessToken = await _tokenService.GenerateToken(user);

                return Ok(new
                {
                    email = user.Email,
                    primeroNome = user.Usuario,
                    accessToken = acessToken,
                });
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuario. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("cadastro_usuario")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(User modelLogin)
        {
            try
            {
                if (modelLogin.Tipo == "externo")
                    return BadRequest("Somente adiministradores podem cadastrar usuarios externos.");

                var user = await _userService.AddUser(modelLogin);

                if (user == null)
                    return BadRequest("Erro ao tentar cadastrar usuario.");

                return Ok(user);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar usuario. Erro: {ex.Message}");
            }
        }

        [HttpPost("authenticate_external_users")]
        public async Task<IActionResult> AuthenticateExternalUsers(User requestUser)
        {
            if (requestUser == null)
            {
                return Unauthorized();
            }
            var externalUser = await _userService.GetExternalUser(requestUser.Usuario, requestUser.Senha);
            if (externalUser == null) return BadRequest("Erro ao tentar recuperar usuario.");

            var userToken = await _tokenService.GenerateTokenForExternalUsers(requestUser);

            if (string.IsNullOrEmpty(userToken))
                return Unauthorized();

            return Ok(new
            {
                email = externalUser.Email,
                primeroNome = externalUser.Usuario,
                accessToken = userToken,
            });
        }
    }
}
