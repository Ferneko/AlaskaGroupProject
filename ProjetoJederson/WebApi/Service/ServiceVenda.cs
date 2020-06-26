using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceVenda
    {
        private DaoVenda dao;
        public ServiceVenda(Contexto db)
        {
            dao = new DaoVenda(db);
        }

        public List<Venda> Delete(long id)
        {
            Venda venda = PesquisarId(id);

            if (venda != null)
            {
                dao.Delete(venda);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Erro ao deleter. Id já deletado");
            }
        }
        public Venda Gravar(Venda objeto)
        {
            return dao.Gravar(objeto);
        }

        public List<Venda> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public Venda PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
     
    }
}
