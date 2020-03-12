using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceSabores
    {
        private DaoSabores dao;

        public ServiceSabores(Contexto db)
        {
            dao = new DaoSabores(db);
        }

        public void Record(Sabores objeto)
        {
            dao.Record(objeto);
        }

        public List<Sabores> ListaTodosAtivos()
        {
            return dao.ListaTodosAtivos();
        }

        public List<Sabores> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Sabores> Search(string texto)
        {
            return dao.Search(texto);
        }

        public Sabores SearchId(long id)
        {
            return dao.SearchId(id);
        }

    }
}
