using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceUsuario
    {
        private DaoUsuario dao;

        public ServiceUsuario(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência

            dao = new DaoUsuario(db); 
        }

        public void Gravar(Usuario objeto)
        {
            dao.Gravar(objeto);
        }

        public List<Usuario> ListaTodosAtivos()
        {
            return dao.ListaTodosAtivos();
        }

        public List<Usuario> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Usuario> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public Usuario PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
