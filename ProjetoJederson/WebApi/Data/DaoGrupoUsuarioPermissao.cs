using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoGrupoUsuarioPermissao
    {
        private Contexto db;
        public DaoGrupoUsuarioPermissao(Contexto db)
        {
            this.db = db;
        }

        public string Delete(GrupoUsuarioPermissao objeto)
        {
            db.GRUPO_USUARIO_PERMISSAO.Remove(objeto);
            db.SaveChanges();
            return "excluído com sucesso";
        }
        public GrupoUsuarioPermissao Gravar(GrupoUsuarioPermissao objeto)
        {
            if (objeto.id == 0)
            {
                db.GRUPO_USUARIO_PERMISSAO.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.GRUPO_USUARIO_PERMISSAO.Update(objeto);

            }
            db.SaveChanges();
            return objeto;
        }



        public List<GrupoUsuarioPermissao> ListaTodos()
        {
            return db.GRUPO_USUARIO_PERMISSAO.ToList();

        }

        public List<GrupoUsuarioPermissao> Pesquisar(string texto)
        {
            return db.GRUPO_USUARIO_PERMISSAO.Where(a => texto.Contains(a.id.ToString()) || a.permissao.nome.Contains(texto) || a.grupoUsuario.nome.Contains(texto)).ToList();

        }

        public GrupoUsuarioPermissao PesquisarId(long id)
        {
            return db.GRUPO_USUARIO_PERMISSAO.Where(a => a.id == id).FirstOrDefault();
        }
    }
}
