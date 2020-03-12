using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceCliente
    {
        private DaoCliente dao;

        public ServiceCliente(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência

            dao = new DaoCliente(db);
        }

        public void Gravar(Cliente objeto)
        {
            dao.Gravar(objeto);
        }

        public List<Cliente> ListaTodosAtivos()
        {
            return dao.ListaTodosAtivos();
        }

        public List<Cliente> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Cliente> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public Cliente PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
