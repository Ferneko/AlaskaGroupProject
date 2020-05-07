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
        public string Delete(long id)
        {
            Adicional objeto = PesquisarPorId(id);

            if (objeto != null)
            {
                return dao.Delete(objeto);
            }
            else
            {
                return "Erro 404 - não encontrado";
            }
        }
        public Adicional Gravar(Adicional objeto)
        {
            if (string.IsNullOrEmpty(objeto.nome))
            {
                throw new Exception("Nome não pode estar em branco");
            }

            if (Pesquisar(objeto.nome).Count > 0)
            {
                throw new Exception("Nome já cadastrado");
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
