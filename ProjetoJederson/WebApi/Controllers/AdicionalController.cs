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
                throw;
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
                throw;
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
                throw;
            }
        }


        [HttpDelete]
        public JsonResult Delete([FromBody] Cliente objeto)
        {
            try
            {
                return Json(serviceAdicional.Delete(objeto.id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}