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
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        [Route("acesso_usuario")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string usuario, string senha)
        {
            try
            {
                var user = await _loginService.GetUser(usuario, senha);
                if (user == null) return BadRequest("Erro ao tentar recuperar usuario.");

                return Ok(user);
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
        public async Task<IActionResult> Post(Login modelLogin)
        {
            try
            {
                var user = await _loginService.AddUser(modelLogin);
                if (user == null) return BadRequest("Erro ao tentar cadastrar usuario.");

                return Ok(user);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar usuario. Erro: {ex.Message}");
            }
        }
    }
}
