using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceCaixa
    {
        private DaoCaixa dao;

        public ServiceCaixa(Contexto db)
        {
            dao = new DaoCaixa(db);
        }

        public void Gravar(Caixa objeto)
        {
            dao.Gravar(objeto);
        }

        public List<Caixa> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Caixa> PesquisarPorData(DateTime velha, DateTime nova)
        {
            return dao.PesquisarPorData(velha, nova);
        }

        public List<Caixa> Delete(long id)
        {
            Caixa objeto = dao.PesquisarId(id);

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

        internal object movimentaocao()
        {
            throw new NotImplementedException();
        }

        public List<Caixa> Pesquisar(DateTime query)
        {
            return dao.Pesquisar(query);
        }

        public decimal CaixaInicial(){
            return dao.CaixaInicial();
        }
    }
}
