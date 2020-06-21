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
        [HttpGet("{id}", Name = "UsuariosPermissao")]
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

        [HttpGet("PesquisarUsuariosPermissao/{query}", Name = "PesquisarUsuariosPermissao")]
        public JsonResult PesquisarUsuariosPermissao(string query)
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
        public JsonResult Post([FromBody] UsuarioPermissao objeto)
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
        public JsonResult Put([FromBody] UsuarioPermissao objeto)
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

        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
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
