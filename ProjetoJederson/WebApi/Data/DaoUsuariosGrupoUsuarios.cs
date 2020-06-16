using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoUsuariosGrupoUsuarios
    {
        private Contexto db;
        public DaoUsuariosGrupoUsuarios(Contexto db)
        {
            this.db = db;
        }

        public string Delete(UsuariosGrupoUsuarios objeto)
        {
            db.USUARIOS_GRUPO_USUARIOS.Remove(objeto);
            db.SaveChanges();
            return "excluído com sucesso";
        }
        public UsuariosGrupoUsuarios Gravar(UsuariosGrupoUsuarios objeto)
        {
            if (objeto.id == 0)
            {
                db.USUARIOS_GRUPO_USUARIOS.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.USUARIOS_GRUPO_USUARIOS.Update(objeto);

            }
            db.SaveChanges();
            return objeto;
        }



        public List<UsuariosGrupoUsuarios> ListaTodos()
        {
            return db.USUARIOS_GRUPO_USUARIOS.ToList();

        }

        public List<UsuariosGrupoUsuarios> Pesquisar(string texto)
        {
            return db.USUARIOS_GRUPO_USUARIOS.Where(a => texto.Contains(a.id.ToString()) || a.usuario.nome.Contains(texto) || a.grupoUsuario.nome.Contains(texto)).ToList();

        }

        public UsuariosGrupoUsuarios PesquisarId(long id)
        {
            return db.USUARIOS_GRUPO_USUARIOS.Where(a => a.id == id).FirstOrDefault();
        }
    }
}
