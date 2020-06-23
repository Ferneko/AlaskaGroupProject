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
    public class GrupoUsuarioPermissaoController : Controller
    {
        private ServiceGrupoUsuarioPermissao service;
        public GrupoUsuarioPermissaoController(Contexto db)
        {
            service = new ServiceGrupoUsuarioPermissao(db);
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            try
            {
                return Json(service.ListarTodosPorGrupoUsuario(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

     

        // POST: api/Usuarios
        [HttpPost]
        public JsonResult Post([FromBody] GrupoUsuarioPermissaoModel objeto)
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

      

        [HttpDelete("{idPermissao}/{idGrupoUsuario}")]
        public JsonResult Delete(long idPermissao, long idGrupoUsuario)
        {
            try
            {
                service.Delete(idPermissao, idGrupoUsuario);
                return Json(StatusCode(200));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarGrupoUsuarioPermissao/{idGrupoUsuario}/{query}", Name = "PesquisarGrupoUsuarioPermissao")]
        public JsonResult PesquisarGrupoUsuarioPermissao(string query ,long idGrupoUsuario)
        {
            try
            {

                return Json(service.ListarTodosPorGrupoUsuario(idGrupoUsuario).Where(a => a.nome.Contains(query) || a.descricao.Contains(query)));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}
