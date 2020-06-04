using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServicePermissao
    {
        private DaoPermissao dao;

        public ServicePermissao(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência

            dao = new DaoPermissao(db);
        }

        public List<Permissao> Delete(long id)
        {
            Permissao cliente = PesquisarId(id);

            if (cliente != null)
            {
                dao.Delete(cliente);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Não encontrado");
            }
        }

        public Permissao Gravar(Permissao objeto)
        {
            if (string.IsNullOrEmpty(objeto.nome))
            {

                throw new Exception("Nome não pode estar em branco");

            }

            return dao.Gravar(objeto);
        }

        public List<Permissao> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Permissao> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public Permissao PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
