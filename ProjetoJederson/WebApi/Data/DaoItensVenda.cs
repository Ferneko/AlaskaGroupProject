using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoItensVenda
    {
        private Contexto db;
        public DaoItensVenda(Contexto db)
        {
            this.db = db;
        }

        public string Delete(ItensVenda objeto)
        {
            db.ITENS_VENDA.Remove(objeto);
            db.SaveChanges();
            return "excluído com sucesso";
        }
        public ItensVenda Gravar(ItensVenda objeto)
        {
            if (objeto.id == 0)
            {
                db.ITENS_VENDA.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.ITENS_VENDA.Update(objeto);

            }
            db.SaveChanges();
            return objeto;
        }



        public List<ItensVenda> ListaTodos()
        {
            return db.ITENS_VENDA.ToList();

        }



        public ItensVenda PesquisarId(long id)
        {
            return db.ITENS_VENDA.Where(a => a.id == id).FirstOrDefault();
        }
    }
}
