using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosPermissaoController : Controller
    {
        // GET: api/UsuariosPermissao
        private ServiceUsuariosPermissao service;
        public UsuariosPermissaoController(Contexto db)
        {
            service = new ServiceUsuariosPermissao(db);
        }

       
       

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            try
            {
                return Json(service.ListarTodosPorUsuarioId(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

       

        // POST: api/Usuarios
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioPermissaoModel objeto)
        {
            try
            {
                return Json(service.Gravar(objeto));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }



        [HttpDelete("{idPermissao}/{idUsuario}")]
        public JsonResult Delete(long idUsuario, long idPermissao)
        {
            try
            {
                service.Delete(idPermissao, idUsuario);
                return Json(StatusCode(200));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
        
        [HttpGet("PesquisarUsuariosPermissao/{idUsuario}/{query}", Name = "PesquisarUsuariosPermissao")]
        public JsonResult PesquisarUsuariosPermissao(string query, long idUsuario)
        {
            try
            {

                return Json(service.ListarTodosPorUsuarioId(idUsuario).Where(a => a.nome.Contains(query) || a.descricao.Contains(query)));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}
