using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoVenda
    {
        private Contexto db;
        public DaoVenda(Contexto db)
        {
            this.db = db;
        }

        public string Delete(Venda objeto)
        {
            db.VENDAS.Remove(objeto);
            db.SaveChanges();
            return "excluído com sucesso";
        }
        public Venda Gravar(Venda objeto)
        {
            if (objeto.id == 0)
            {
                db.VENDAS.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.VENDAS.Update(objeto);

            }
            db.SaveChanges();
            return objeto;
        }

      

        public List<Venda> ListaTodos()
        {
            return db.VENDAS.ToList();

        }

      

        public Venda PesquisarId(long id)
        {
            return db.VENDAS.Where(a => a.id == id).FirstOrDefault();
        }

       
    }
}
