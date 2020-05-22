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
    public class SaboresController : Controller
    {

        private ServiceSabores serviceSabores;
        public SaboresController(Contexto db)
        {
            serviceSabores = new ServiceSabores(db);
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return Json(serviceSabores.ListaTodos());
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }
        }
        [HttpGet("{id}", Name = "GetSabores")]
        public JsonResult Get(int id)
        {

            try
            {
                return Json(serviceSabores.SearchId(id));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
 
        [HttpPost]

        public JsonResult Post([FromBody]Sabores objeto)
        {
            try
            {
                return Json(serviceSabores.Record(objeto));
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
                return Json(serviceSabores.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarSabores/{query}", Name = "PesquisarSabores")]
        public JsonResult PesquisarSabores(string query)
        {
            try
            {

                return Json(serviceSabores.Search(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}