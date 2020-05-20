using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Exceptions;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceUsuario
    {
        private DaoUsuario dao;

        public ServiceUsuario(Contexto db)
        {
            dao = new DaoUsuario(db);
        }
        public List<Usuario> Delete(long id)
        {
            Usuario usuario = PesquisarId(id);

            if (usuario != null)
            {
                dao.Delete(usuario);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Erro ao deleter. Id já deletado");
            }
        }
        public Usuario Gravar(Usuario objeto)
        {
            if (string.IsNullOrEmpty(objeto.nome))
            {
                throw new Exception("Nome não pode estar em branco");
            }

            if (string.IsNullOrEmpty(objeto.login))
            {
                throw new Exception("login não pode estar em branco");

            }

            if (string.IsNullOrEmpty(objeto.senha))
            {
                throw new Exception("senha não pode estar em branco");
            }

          
            return dao.Gravar(objeto);
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

        public bool PesquisarId(string Login, string Senha)
        {
            var resultado = dao.PesquisarPorLoginSenha(Login, Senha);
            if (resultado != null && resultado.login == Login && resultado.senha == Senha)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
