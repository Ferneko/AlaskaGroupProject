using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceAdicional
    {
        private DaoAdicional dao;

        public ServiceAdicional(Contexto db)
        {
            dao = new DaoAdicional(db);
        }
        public List<Adicional> Delete(long id)
        {
            Adicional objeto = PesquisarPorId(id);

            if (objeto != null)
            {
                dao.Delete(objeto);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Erro ao deleter. Id já deletado");
            }
        }
        public Adicional Gravar(Adicional objeto)
        {
            if (string.IsNullOrEmpty(objeto.nome))
            {
                throw new Exception("Nome não pode estar em branco");
            }

        

            return dao.Gravar(objeto);
        }

        public List<Adicional> ListaTodosAtivos()
        {
            return dao.ListaTodosAtivos();
        }

        public List<Adicional> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Adicional> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public Adicional PesquisarPorId(long id)
        {
            return dao.PesquisarPorId(id);
        }
    }
}
