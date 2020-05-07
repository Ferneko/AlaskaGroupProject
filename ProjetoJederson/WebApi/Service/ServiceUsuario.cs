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
        public string Delete(long id)
        {
            Usuario usuario = PesquisarId(id);

            if (usuario != null)
            {
                return dao.Delete(usuario);
            }
            else
            {
                return "Usuário não encontrado";
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

            if (Pesquisar(objeto.login).Count > 0)
            {
                throw new RegistroRepetidoException("Login já cadastrado");
            }

            if(Pesquisar(objeto.nome).Count > 0)
            {
                throw new RegistroRepetidoException("Nome já cadastrado");
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
