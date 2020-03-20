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
    public class AdicionalController : ControllerBase
    {

        private ServiceAdicional serviceAdicional;
        public AdicionalController(Contexto db)
        {
            serviceAdicional = new ServiceAdicional(db);
        }

        [HttpGet]

        public IEnumerable<Adicional> Get()
        {
            try
            {
                return serviceAdicional.ListaTodos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}", Name = "Get")]
        public Adicional Get(int id)
        {

            try
            {
                return serviceAdicional.PesquisarPorId(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]

        public void Post([FromBody] Adicional objeto)
        {
            try
            {
                serviceAdicional.Record(objeto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}