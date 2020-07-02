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
    public class VendasController : Controller
    {
        private ServiceVenda service;
        public VendasController(Contexto db)
        {
            service = new ServiceVenda(db);
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(Roles = "acessarListaVendas")]
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

        [HttpGet("Modelo", Name ="Modelo")]
        public JsonResult Modelo()
        {
            try
            {
                return Json(service.Modelo());
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }


        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "getVendas")]
        [Authorize(Roles = "acessarListaVendas")]
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

        [HttpGet("PesquisarVendas/{query}", Name = "PesquisarVendas")]
        public JsonResult PesquisarVendas(int query)
        {
            try
            {

                return Json(service.PesquisarId(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // POST: api/Usuarios
        [HttpPost]
        [Authorize(Roles = "cadastrarNovoVendas")]
        public JsonResult Post([FromBody] VendasModel objeto)
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
        [Authorize(Roles = "editarVendas")]
        public JsonResult Put([FromBody] VendasModel objeto)
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
        [Authorize(Roles = "excluirVendas")]
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
