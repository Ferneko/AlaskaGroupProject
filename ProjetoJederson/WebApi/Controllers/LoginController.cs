using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ServiceUsuario servicoUsuario;
        public LoginController(Contexto _db)
        {
            servicoUsuario = new ServiceUsuario(_db);
        }

        [HttpPost]
        public string Post([FromBody] Usuario usuario)
        {

          
            if(servicoUsuario.PesquisarId(usuario.login, usuario.senha))
            {
                // Gera o Token
                var token = GenerateToken(usuario);

                return token;
            }
            else
            {
                return Forbid().ToString();
                //return StatusCode(403).ToString();
            }
           
        }

        private string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("@sucesso13@");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.login.ToString()),
                    new Claim(ClaimTypes.Role, user.nome.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}