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
    public class AcompanhamentosController : ControllerBase
    {
        private ServiceAcompanhamentos serviceAcompanhamentos;
        public AcompanhamentosController(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            serviceAcompanhamentos = new ServiceAcompanhamentos(db);
        }

        // GET: api/Acompanhamentos
        [HttpGet]
        public IEnumerable<Acompanhamentos> Get()
        {
            try
            {
                return serviceAcompanhamentos.ListaTodos();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // GET: api/Acompanhamentos/5
        [HttpGet("{id}", Name = "GetAcompanhamento")]
        public Acompanhamentos Get(int id)
        {
            try
            {
                return serviceAcompanhamentos.PesquisarId(id);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        // POST: api/Acompanhamentos
        [HttpPost]
        public void Post([FromBody] Acompanhamentos objeto)
        {
            try
            {
                serviceAcompanhamentos.Gravar(objeto);
            }
            catch (Exception)
            {
                throw;
            }
   
        }

    }
}