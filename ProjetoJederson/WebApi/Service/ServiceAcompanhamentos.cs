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

        public ServiceAcompanhamentos(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
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


            if (string.IsNullOrEmpty(objeto.descricao))
            {
                throw new Exception("descricao não pode estar em branco");
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
    }
}