using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoUsuariosPermissao
    {
        private Contexto db;
        public DaoUsuariosPermissao(Contexto db)
        {
            this.db = db;
        }

        public string Delete(UsuarioPermissao objeto)
        {
            db.USUARIO_PERMISSAO.Remove(objeto);
            db.SaveChanges();
            return "excluído com sucesso";
        }
        public UsuarioPermissao Gravar(UsuarioPermissao objeto)
        {
            if (objeto.id == 0)
            {
                db.USUARIO_PERMISSAO.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.USUARIO_PERMISSAO.Update(objeto);

            }
            db.SaveChanges();
            return objeto;
        }



        public List<UsuarioPermissao> ListaTodos()
        {
            return db.USUARIO_PERMISSAO.ToList();

        }

        public List<UsuarioPermissao> Pesquisar(string texto)
        {
            return db.USUARIO_PERMISSAO.Where(a => texto.Contains(a.id.ToString()) || a.usuario.nome.Contains(texto) || a.permissao.nome.Contains(texto)).ToList();

        }

        public UsuarioPermissao PesquisarId(long id)
        {
            return db.USUARIO_PERMISSAO.Where(a => a.id == id).FirstOrDefault();
        }
    }
}
