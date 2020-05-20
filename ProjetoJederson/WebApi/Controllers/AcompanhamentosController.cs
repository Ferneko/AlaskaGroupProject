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
    public class AcompanhamentosController : Controller
    {
        private ServiceAcompanhamentos serviceAcompanhamentos;
        public AcompanhamentosController(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            serviceAcompanhamentos = new ServiceAcompanhamentos(db);
        }

        // GET: api/Acompanhamentos
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return Json(serviceAcompanhamentos.ListaTodos());
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // GET: api/Acompanhamentos/5
        [HttpGet("{id}", Name = "GetAcompanhamento")]
        public JsonResult Get(int id)
        {
            try
            {
                return Json(serviceAcompanhamentos.PesquisarId(id));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }
          
        }

      

        // POST: api/Acompanhamentos
        [HttpPost]
        public JsonResult Post([FromBody] Acompanhamentos objeto)
        {
            try
            {
                return Json(serviceAcompanhamentos.Gravar(objeto));
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
                return Json(serviceAcompanhamentos.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarAcompanhamentos/{query}", Name = "PesquisarAcompanhamentos")]
        public JsonResult PesquisarAcompanhamentos(string query)
        {
            try
            {

                return Json(serviceAcompanhamentos.Pesquisar(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

    }
}