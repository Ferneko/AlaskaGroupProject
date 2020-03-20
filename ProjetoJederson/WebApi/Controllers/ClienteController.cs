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
    public class ClienteController : ControllerBase
    {
        private ServiceCliente serviceCliente;
        public ClienteController(Contexto db)
        {
            serviceCliente = new ServiceCliente(db);
        }
        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            try
            {
                return serviceCliente.ListaTodos();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetCliente")]
        public Cliente Get(int id)
        {
            try
            {
                return serviceCliente.PesquisarId(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: api/Usuarios
        [HttpPost]
        public void Post([FromBody] Cliente objeto)
        {
            try
            {
                serviceCliente.Gravar(objeto);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}