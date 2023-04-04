using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Protocolo.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Protocolo.Publisher.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        public IConfiguration _configuration;

        public AutenticacaoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ObterTokenAcesso([FromBody] UsuarioEntity model)
        {
            IActionResult retorno = Unauthorized();

            bool usuarioValido = ValidarUsuario(model);
            if (usuarioValido)
            {
                var tokenGerado = GerarJSONWebToken(model);
                retorno = Ok(new { token = tokenGerado });
            }

            return retorno;
        }

        private bool ValidarUsuario(UsuarioEntity model) => model.Login == "valid" && model.Senha == "valid@1234";

        private object GerarJSONWebToken(UsuarioEntity usuario)
        {
            var chaveSegura = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credenciais = new SigningCredentials(chaveSegura, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
