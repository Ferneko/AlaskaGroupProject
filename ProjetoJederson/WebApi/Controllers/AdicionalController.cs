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
    public class AdicionalController : Controller
    {

        private ServiceAdicional serviceAdicional;
        public AdicionalController(Contexto db)
        {
            serviceAdicional = new ServiceAdicional(db);
        }

        [HttpGet]

        public JsonResult Get()
        {
            try
            {
                return Json(serviceAdicional.ListaTodos());
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }
        }
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {

            try
            {
                return Json(serviceAdicional.PesquisarPorId(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpPost]

        public JsonResult Post([FromBody] Adicional objeto)
        {
            try
            {
                return Json(serviceAdicional.Gravar(objeto));
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
                return Json(serviceAdicional.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarAdicional/{query}", Name = "PesquisarAdicional")]
        public JsonResult PesquisarAdicional(string query)
        {
            try
            {

                return Json(serviceAdicional.Pesquisar(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}