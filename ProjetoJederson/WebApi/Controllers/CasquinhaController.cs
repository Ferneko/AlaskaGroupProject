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
    public class CasquinhaController : Controller
    {
        private ServiceCasquinha serviceCasquinha;
        public CasquinhaController(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            serviceCasquinha = new ServiceCasquinha(db);
        }

        // GET: api/Casquinha
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return Json(serviceCasquinha.ListAll());
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/Casquinha/5
        [HttpGet("{id}", Name = "GetCasquinha")]
        public JsonResult Get(int Id)
        {
           
            try
            {
                return Json(serviceCasquinha.SearchId(Id));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // POST: api/Casquinha
        [HttpPost]
        public JsonResult Post([FromBody] Casquinha objeto)
        {
            try
            {
                return Json(serviceCasquinha.Record(objeto));
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpDelete]
        public JsonResult Delete([FromBody] Casquinha objeto)
        {
            try
            {
                return Json(serviceCasquinha.Delete(objeto.Id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}
