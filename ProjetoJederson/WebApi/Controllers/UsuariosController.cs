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
    public class UsuariosController : ControllerBase
    {
        private ServiceUsuario serviceUsuario;
        public UsuariosController(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            serviceUsuario = new ServiceUsuario(db);
        }

        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            try
            {
                return serviceUsuario.ListaTodos();
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "Get")]
        public Usuario Get(int id)
        {
            try
            {
                return serviceUsuario.PesquisarId(id);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        // POST: api/Usuarios
        [HttpPost]
        public void Post([FromBody] Usuario objeto)
        {
            try
            {
                serviceUsuario.Gravar(objeto);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

       
    }
}
