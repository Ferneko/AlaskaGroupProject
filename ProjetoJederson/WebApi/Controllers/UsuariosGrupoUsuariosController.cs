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
    public class UsuariosGrupoUsuariosController : Controller
    {
        private ServiceUsuariosGrupoUsuarios service;
        public UsuariosGrupoUsuariosController(Contexto db)
        {
            service = new ServiceUsuariosGrupoUsuarios(db);
        }

        // GET: api/Usuarios
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return Json(service.ListaTodos());
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetGrupoUsuario")]
        public JsonResult Get(int id)
        {
            try
            {
                return Json(service.PesquisarId(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarGrupoUsuario/{query}", Name = "PesquisarGrupoUsuario")]
        public JsonResult PesquisarGrupoUsuario(string query)
        {
            try
            {

                return Json(service.Pesquisar(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // POST: api/Usuarios
        [HttpPost]
        public JsonResult Post([FromBody] UsuariosGrupoUsuarios objeto)
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
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            try
            {
                return Json(service.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}
