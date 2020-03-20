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
    public class SaboresController : ControllerBase
    {

        private ServiceSabores serviceSabores;
        public SaboresController(Contexto db)
        {
            serviceSabores = new ServiceSabores(db);
        }

        [HttpGet]
        public List<Sabores> Get()
        {
            try
            {
                return serviceSabores.ListaTodos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id}", Name = "GetSabores")]
        public Sabores Get(int id)
        {

            try
            {
                return serviceSabores.SearchId(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]

        public void Post([FromBody] Sabores objeto)
        {
            try
            {
                serviceSabores.Record(objeto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}