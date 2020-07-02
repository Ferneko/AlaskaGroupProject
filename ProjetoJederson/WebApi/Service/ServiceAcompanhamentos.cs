using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceAcompanhamentos
    {
        private DaoAcompanhamentos dao;
        private ServiceEstoque serviceEstoque;
        public ServiceAcompanhamentos(Contexto db)
        {
            dao = new DaoAcompanhamentos(db);
        }
        
        public List<Acompanhamentos> Delete(long id)
        {
            Acompanhamentos objeto = PesquisarId(id);

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
        public Acompanhamentos Gravar(Acompanhamentos objeto)
        {
            if (string.IsNullOrEmpty(objeto.nome))
            {
                throw new Exception("Nome não pode estar em branco");
            }

            return dao.Gravar(objeto);
        }

        public List<Acompanhamentos> ListaTodosAtivos()
        {
            return dao.ListaTodosAtivos();
        }

        public List<Acompanhamentos> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Acompanhamentos> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public Acompanhamentos PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }

        public List<Acompanhamentos> ListaTodosAtivosEmEstoque()
        {
            List<Acompanhamentos> retorno = new List<Acompanhamentos>();
            foreach (var item in ListaTodosAtivos())
            {
                if(dao.saldoAcompanhamento(item.id) > 0)
                {
                    retorno.Add(item);
                }
                
            }

            return retorno;
        }
    }
}