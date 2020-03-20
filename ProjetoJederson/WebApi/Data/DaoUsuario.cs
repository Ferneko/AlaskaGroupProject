using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoUsuario
    {
        private Contexto db;
        public DaoUsuario(Contexto _db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            db = _db;
        }

        public void Gravar(Usuario objeto)
        {
            if(objeto.id == 0)
            {
                db.USUARIOS.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.USUARIOS.Update(objeto);
                db.SaveChanges();
            }
        }

        public List<Usuario> ListaTodosAtivos()
        {
            return db.USUARIOS.Where(a => a.ativo == true).ToList();
        }

        public List<Usuario> ListaTodos()
        {
            return db.USUARIOS.ToList();
        }

        public List<Usuario> Pesquisar(string texto)
        {
            return db.USUARIOS.Where(a => texto.Contains(a.id.ToString()) || a.nome.Contains(texto) || a.login.Contains(texto)).ToList();

        }

        public Usuario PesquisarId(long id)
        {
            return db.USUARIOS.Where(a => a.id == id).FirstOrDefault();
        }

        public Usuario PesquisarPorLoginSenha(string Login, string Senha)
        {
            return db.USUARIOS.Where(a => a.login == Login && a.senha == Senha).FirstOrDefault();
        }

    }
}
