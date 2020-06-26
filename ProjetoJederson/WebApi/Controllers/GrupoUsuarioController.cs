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
    public class GrupoUsuarioController : Controller
    {
        private ServiceGrupoUsuario service;
        public GrupoUsuarioController(Contexto db)
        {
            service = new ServiceGrupoUsuario(db);
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(Roles = "acessarListaGrupoUsuario")]
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
        [Authorize(Roles = "acessarListaGrupoUsuario")]
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
        [Authorize(Roles = "cadastrarNovoGrupoUsuario")]
        public JsonResult Post([FromBody] GrupoUsuario objeto)
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
        [Authorize(Roles = "excluirGrupoUsuario")]
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