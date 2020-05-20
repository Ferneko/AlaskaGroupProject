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
                return Json(serviceCasquinha.ListaTodos());
            }
            catch (Exception ex)
            {

                return Json(new { erro = ex.Message + " " + ex.InnerException });
            }
        }





        // GET: api/Casquinha/5
        [HttpGet("{id}", Name = "GetCasquinha")]
        public JsonResult Get(int Id)
        {

            try
            {
                return Json(serviceCasquinha.PesquisarId(Id));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarCasquinha/{query}", Name = "PesquisarCasquinha")]
        public JsonResult PesquisarCasquinha(string query)
        {
            try
            {
                return Json(serviceCasquinha.Pesquisar(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }



        // POST: api/Casquinha
        [HttpPost]
        public JsonResult Post([FromBody] Casquinha objeto)
        {
            try
            {
                return Json(serviceCasquinha.Gravar(objeto));
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
                return Json(serviceCasquinha.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}
