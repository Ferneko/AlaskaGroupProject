using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoPermissao
    {
        private Contexto db;
        public DaoPermissao(Contexto db)
        {
            this.db = db;
        }

        public string Delete(Permissao objeto)
        {
            db.PERMISSAO.Remove(objeto);
            db.SaveChanges();
            return "Usuário excluído com sucesso";
        }
        public Permissao Gravar(Permissao objeto)
        {
            if (objeto.id == 0)
            {
                db.PERMISSAO.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.PERMISSAO.Update(objeto);

            }
            db.SaveChanges();
            return objeto;
        }

      

        public List<Permissao> ListaTodos()
        {
            return db.PERMISSAO.ToList();

        }

        public List<Permissao> Pesquisar(string texto)
        {
            return db.PERMISSAO.Where(a => texto.Contains(a.id.ToString()) || a.nome.Contains(texto) || a.descricao.Contains(texto)).ToList();

        }

        public Permissao PesquisarId(long id)
        {
            return db.PERMISSAO.Where(a => a.id == id).FirstOrDefault();
        }

      
    }
}
