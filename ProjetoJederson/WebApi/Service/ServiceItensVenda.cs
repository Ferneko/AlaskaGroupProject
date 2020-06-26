using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceItensVenda
    {
        private DaoItensVenda dao;
        public ServiceItensVenda(Contexto db)
        {
            dao = new DaoItensVenda(db);
        }

        public List<ItensVenda> Delete(long id)
        {
            ItensVenda venda = PesquisarId(id);

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
        public ItensVenda Gravar(ItensVenda objeto)
        {
            return dao.Gravar(objeto);
        }

        public List<ItensVenda> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public ItensVenda PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
