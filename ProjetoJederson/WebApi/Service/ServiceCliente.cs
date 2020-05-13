using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Exceptions;
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

        public List<Cliente> Delete(long id)
        {
            Cliente cliente = PesquisarId(id);

            if (cliente != null)
            {
                dao.Delete(cliente);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Cliente não encontrado");
            }
        } 

        public Cliente Gravar(Cliente objeto)
        {
            if (string.IsNullOrEmpty(objeto.nome))
            {
               
                    throw new Exception("Nome não pode estar em branco");
              
            }

            return  dao.Gravar(objeto);
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
