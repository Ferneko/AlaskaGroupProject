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
    public class EstoqueController : Controller
    {
        private ServiceEstoque service;
        public EstoqueController(Contexto db)
        {
            service = new ServiceEstoque(db);
        }

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


        [HttpGet("PesquisarEstoque/{query}", Name = "PesquisarEstoque")]
        public JsonResult PesquisarEstoque(DateTime query)
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

        [HttpGet("SaldoCasquinha/{query}", Name = "SaldoCasquinha")]
        public JsonResult SaldoCasquinha(int query)
        {
            try
            {
                return Json(service.saldoCasquinha(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }




        [HttpPost]
        public JsonResult Post([FromBody] Estoque estoque)
        {
            try
            {
                service.Gravar(estoque);
                return Json(new { Sucesso = "Sucesso" });
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException }); 
            }
        }

        [HttpGet("Movimentacao", Name = "Movimentacao")]
        public JsonResult Movimentacao()
        {
            try
            {
                return Json(service.movimentaocao());
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("NovaEntrada", Name = "NovaEntrada")]
        public JsonResult NovaEntrada()
        {
            try
            {
                return Json(service.novaEntrada());
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
                return Json(service.Delete(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }
    }
}