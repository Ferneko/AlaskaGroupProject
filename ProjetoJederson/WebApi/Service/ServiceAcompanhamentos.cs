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

        public void Gravar(Acompanhamentos objeto)
        {
            dao.Gravar(objeto);
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