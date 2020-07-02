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
        private ServiceUsuariosPermissao serviceUsuariosPermissao;
        public LoginController(Contexto _db)
        {
            servicoUsuario = new ServiceUsuario(_db);
            serviceUsuariosPermissao = new ServiceUsuariosPermissao(_db);
        }

        [HttpPost]
        public dynamic Post([FromBody] Usuario usuario)
        {

            Usuario logado = servicoUsuario.PesquisarId(usuario.login, usuario.senha);
            if (logado != null)
            {

                //return GenerateToken(logado); 
                return GenerateJSONWebToken(logado); 
            }
            else
            {
                return Forbid().ToString();
                //return StatusCode(403).ToString();
            }

        }

        private RetornoLogin GenerateToken(Usuario user)
        {
            RetornoLogin retorno = new RetornoLogin();
            retorno.roles = new List<string>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("@sucesso13@");
            var tokenDescriptor = new SecurityTokenDescriptor();

            

            List<Claim> ListaClaims = new List<Claim>();
            ListaClaims.Add(new Claim(ClaimTypes.PrimarySid, user.id.ToString()));
            ListaClaims.Add(new Claim(ClaimTypes.Name, user.login.ToString()));
            

            foreach (var item in serviceUsuariosPermissao.ListarPermissoesUsuario(user.id))
            {
                ListaClaims.Add(new Claim(ClaimTypes.Role, item.role  ));
                retorno.roles.Add(item.role);

            }

            tokenDescriptor.Subject = new ClaimsIdentity(ListaClaims);
            tokenDescriptor.Expires = DateTime.UtcNow.AddHours(2);
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var token = tokenHandler.CreateToken(tokenDescriptor);

           
            retorno.token = tokenHandler.WriteToken(token);
           
            return retorno;
        }

   

        private RetornoLogin GenerateJSONWebToken(Usuario userInfo)
        {
            RetornoLogin retorno = new RetornoLogin();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a2e63ee01401aaeca78be023dfbb8c59"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userInfo.login));
            claims.Add(new Claim(ClaimTypes.Name, userInfo.nome));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            foreach (var item in serviceUsuariosPermissao.ListarPermissoesUsuario(userInfo.id))
            {
                claims.Add(new Claim(ClaimTypes.Role, item.role));
                retorno.roles.Add(item.role);

            }

            var token = new JwtSecurityToken("Test.com",
              "Test.com",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

           
            retorno.token = new JwtSecurityTokenHandler().WriteToken(token); ;
            return retorno;
        }

    }

  

    public class RetornoLogin
    {
        public RetornoLogin()
        {
            roles = new List<string>();
        }
        public string token { get; set; }
        public List<string> roles { get; set; }
    }
}