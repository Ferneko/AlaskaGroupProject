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
    public class CasquinhaController : ControllerBase
    {
        private ServiceCasquinha serviceCasquinha;
        public CasquinhaController(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            serviceCasquinha = new ServiceCasquinha(db);
        }

        // GET: api/Casquinha
        [HttpGet]
        public IEnumerable<Casquinha> Get()
        {
            try
            {
                return serviceCasquinha.ListAll();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/Casquinha/5
        [HttpGet("{id}", Name = "GetCasquinha")]
        public List<Casquinha> Get(int Id, string Name, string Type, decimal Price)
        {
           
            try
            {
                return serviceCasquinha.SearchAll(Id, Name, Type, Price);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: api/Casquinha
        [HttpPost]
        public void Post([FromBody] Casquinha objeto)
        {
            try
            {
                serviceCasquinha.Record(objeto);
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
