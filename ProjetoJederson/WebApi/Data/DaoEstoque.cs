using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoEstoque
    {
        private Contexto db;

        public DaoEstoque(Contexto _db)
        {
            db = _db;
        }

        public List<Estoque> ListaTodos()
        {
            return db.ESTOQUE.Include(c => c.casquinha).Include(a => a.adicional).Include(b => b.acompanhamento).Include(d => d.sabores).ToList();
        }

        public void Gravar(Estoque objeto)
        {
            if (objeto.id > 0)
            {
                db.ESTOQUE.Update(objeto);
            }
            else
            {
                db.ESTOQUE.Add(objeto);
            }
            db.SaveChanges();
        }
        public List<Estoque> PesquisarPorData(DateTime velha, DateTime nova)
        {
            return db.ESTOQUE.Where(a => a.data >= velha && a.data <= nova).ToList();
        }

        public string Delete(Estoque objeto)
        {
            db.ESTOQUE.Remove(objeto);
            db.SaveChanges();
            return "excluído com sucesso";
        }

        public Estoque PesquisarId(long id)
        {
            return db.ESTOQUE.Where(a => a.id == id).FirstOrDefault();
        }

    }
}
