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
            List<Usuario> lista = new List<Usuario>();
            lista.Add(new Usuario() { id = 1, ativo = true, login = "Fernando" });
            lista.Add(new Usuario() { id = 2, ativo = true, login = "Isabela" });
            lista.Add(new Usuario() { id = 3, ativo = true, login = "Gustavo" });
            lista.Add(new Usuario() { id = 4, ativo = true, login = "Rafael" });
            lista.Add(new Usuario() { id = 5, ativo = true, login = "Igor" });

            return lista;
        }

        public List<Usuario> ListaTodos()
        {
            List<Usuario> lista = new List<Usuario>();
            lista.Add(new Usuario() { id = 1, ativo = true, login = "Fernando" });
            lista.Add(new Usuario() { id = 2, ativo = true, login = "Isabela" });
            lista.Add(new Usuario() { id = 3, ativo = true, login = "Gustavo" });
            lista.Add(new Usuario() { id = 4, ativo = true, login = "Rafael" });
            lista.Add(new Usuario() { id = 5, ativo = true, login = "Igor" });

            return lista;
        }

        public List<Usuario> Pesquisar(string texto)
        {
            return new List<Usuario>();
        }

        public Usuario PesquisarId(long id)
        {
            return new Usuario();
        }

    }
}
