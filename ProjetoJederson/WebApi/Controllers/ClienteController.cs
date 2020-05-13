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
    public class ClienteController : Controller
    {
        private ServiceCliente serviceCliente;
        public ClienteController(Contexto db)
        {
            serviceCliente = new ServiceCliente(db);
        }
        // GET: api/Usuarios
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return Json(serviceCliente.ListaTodos());
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetCliente")]
        public JsonResult Get(int id)
        {
            try
            {
                return Json(serviceCliente.PesquisarId(id));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarCliente/{query}", Name = "PesquisarCliente")]
        public JsonResult PesquisarCliente(string query)
        {
            try
            {
                return Json(serviceCliente.Pesquisar(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // POST: api/Usuarios
        [HttpPost]
        public JsonResult Post([FromBody] Cliente objeto)
        {
            try
            {
                return Json(serviceCliente.Gravar(objeto));
            }
            catch (Exception ex )
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            try
            {
                return Json(serviceCliente.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}