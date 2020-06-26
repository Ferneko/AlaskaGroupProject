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
    public class CaixaController : Controller
    {
        private ServiceCaixa service;
        public CaixaController(Contexto db)
        {
            service = new ServiceCaixa(db);
        }

        [HttpGet]
        [Authorize(Roles = "acessarListaCaixa")]
        public JsonResult Get()
        {
            try
            {
                decimal valor = service.CaixaInicial();
                return Json(service.ListaTodos());
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }
        }


        [HttpGet("CaixaSaldo", Name = "CaixaSaldo")]
        public JsonResult CaixaSaldo()
        {
            try
            {
                return Json(service.CaixaInicial());
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpPost]
        [Authorize(Roles = "cadastrarNovoCaixa")]
        public JsonResult Post([FromBody] Caixa caixa)
        {
            try
            {
                service.Gravar(caixa);
                return Json(new { Sucesso = "Sucesso" });
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }
        }

       
        [HttpGet("Movimentacao", Name = "MovimentacaoCaixa")]
        public JsonResult MovimentacaoCaixa()
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

        [HttpGet("PesquisarCaixa/{query}", Name = "PesquisarCaixa")]
        public JsonResult PesquisarCaixa(DateTime query)
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

        [Authorize(Roles = "excluirCaixa")]
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