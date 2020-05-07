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
                throw;
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

                throw;
            }

        }

        [HttpPost]

        public JsonResult Post([FromBody] Sabores objeto)
        {
            try
            {
                return Json(serviceSabores.Record(objeto));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpDelete]
        public JsonResult Delete([FromBody] Sabores objeto)
        {
            try
            {
                return Json(serviceSabores.Delete(objeto.id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}