using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoGrupoUsuario
    {
        private Contexto db;
        public DaoGrupoUsuario(Contexto db)
        {
            this.db = db;
        }

        public string Delete(GrupoUsuario objeto)
        {
            db.GRUPO_USUARIO.Remove(objeto);
            db.SaveChanges();
            return "Usuário excluído com sucesso";
        }
        public GrupoUsuario Gravar(GrupoUsuario objeto)
        {
            if (objeto.id == 0)
            {
                db.GRUPO_USUARIO.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.GRUPO_USUARIO.Update(objeto);

            }
            db.SaveChanges();
            return objeto;
        }

       

        public List<GrupoUsuario> ListaTodos()
        {
            return db.GRUPO_USUARIO.ToList();

        }

        public List<GrupoUsuario> Pesquisar(string texto)
        {
            return db.GRUPO_USUARIO.Where(a => texto.Contains(a.id.ToString()) || a.nome.Contains(texto) ).ToList();

        }

        public GrupoUsuario PesquisarId(long id)
        {
            return db.GRUPO_USUARIO.Where(a => a.id == id).FirstOrDefault();
        }

        
    }
}
