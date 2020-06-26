using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Exceptions;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private ServiceUsuario serviceUsuario;
        public UsuariosController(Contexto db)
        {
            serviceUsuario = new ServiceUsuario(db);
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(Roles = "acessarListaUsuarios")]
        public JsonResult Get()
        {
            try
            {
                return Json(serviceUsuario.ListaTodos());
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetUsuario")]
        [Authorize(Roles = "acessarListaUsuarios")]
        public JsonResult Get(int id)
        {
            try
            {
                return Json(serviceUsuario.PesquisarId(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarUsuario/{query}", Name = "PesquisarUsuario")]
        public JsonResult PesquisarUsuario(string query)
        {
            try
            {
               
                return Json(serviceUsuario.Pesquisar(query));
            }
            catch (Exception ex)
            {
                
                return Json(new { Erro = ex.Message + " " + ex.InnerException});
            }

        }

        // POST: api/Usuarios
        [HttpPost]
        [Authorize(Roles = "cadastrarNovoUsuarios")]
        public JsonResult Post([FromBody] Usuario objeto)
        {
            try
            {
                return Json(serviceUsuario.Gravar(objeto));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
        [HttpDelete]
        [Authorize(Roles = "excluirUsuarios")]
        public JsonResult Delete(int id)
        {
            try
            {
                return Json(serviceUsuario.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }


    }
}
