using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosGrupoUsuariosController : Controller
    {
        private ServiceUsuariosGrupoUsuarios service;
        public UsuariosGrupoUsuariosController(Contexto db)
        {
            service = new ServiceUsuariosGrupoUsuarios(db);
        }

      

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        [Authorize(Roles = "acessarListaUsuarioGrupoUsuarios")]
        public JsonResult Get(int id)
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
        [Authorize(Roles = "cadastrarNovoUsuarioGrupoUsuarios")]
        public JsonResult Post([FromBody] UsuariosGrupoUsuariosModel objeto)
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

        // POST: api/Usuarios
        [HttpPut]
        [Authorize(Roles = "editarUsuarioGrupoUsuarios")]
        public JsonResult Put([FromBody] UsuariosGrupoUsuariosModel objeto)
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

        [HttpDelete("{idGrupoUsuario}/{idUsuario}")]
        [Authorize(Roles = "excluirUsuarioGrupoUsuarios")]
        public JsonResult Delete(long idGrupoUsuario, long idUsuario)
        {
            try
            {
                service.Delete(idGrupoUsuario, idUsuario);
                return Json(StatusCode(200));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarUsuariosGrupoUsuarios/{idUsuario}/{query}", Name = "PesquisarUsuariosGrupoUsuarios")]
        public JsonResult PesquisarUsuariosGrupoUsuarios(string query, long idUsuario)
        {
            try
            {

                return Json(service.ListarTodosPorUsuarioId(idUsuario).Where(a => a.nome.Contains(query)));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}
