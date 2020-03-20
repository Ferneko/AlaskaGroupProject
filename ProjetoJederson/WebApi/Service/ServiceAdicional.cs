using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Service
{
    public class ServiceAdicional
    {
        private DaoAdicional dao;

        public ServiceAdicional(Contexto db)
        {
            dao = new DaoAdicional(db);
        }

        public void Gravar(Adicional objeto)
        {
            dao.Gravar(objeto);
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
