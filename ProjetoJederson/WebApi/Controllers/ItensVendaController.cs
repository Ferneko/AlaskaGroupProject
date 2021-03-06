﻿using System;
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
    public class ItensVendaController : Controller
    {
        // GET: api/UsuariosPermissao
        private ServiceItensVenda service;
        public ItensVendaController(Contexto db)
        {
            service = new ServiceItensVenda(db);
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(Roles = "acessarListaVendas")]
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

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "ItensVenda")]
        [Authorize(Roles = "acessarListaVendas")]
        public JsonResult Get(int id)
        {
            try
            {
                return Json(service.PesquisarId(id));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpGet("PesquisarItensVenda/{query}", Name = "PesquisarItensVenda")]
        public JsonResult PesquisarItensVenda(int query)
        {
            try
            {

                return Json(service.PesquisarId(query));
            }
            catch (Exception ex)
            {

                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // POST: api/Usuarios
        [HttpPost]
        [Authorize(Roles = "cadastrarNovoVendas")]
        public JsonResult Post([FromBody] ItensVenda objeto)
        {
            try
            {
                return Json(service.Gravar(objeto));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        // POST: api/Usuarios
        [HttpPut]
        [Authorize(Roles = "editarVendas")]
        public JsonResult Put([FromBody] ItensVenda objeto)
        {
            try
            {
                return Json(service.Gravar(objeto));
            }
            catch (Exception ex)
            {
                return Json(new { Erro = ex.Message + " " + ex.InnerException });
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "excluirVendas")]
        public JsonResult Delete(long id)
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
