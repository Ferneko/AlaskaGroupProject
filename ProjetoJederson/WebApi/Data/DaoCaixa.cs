using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoCaixa
    {
        private Contexto db;

        public DaoCaixa(Contexto _db)
        {
            db = _db;
        }

        public List<Caixa> ListaTodos()
        {
            return db.CAIXA.ToList();
        }

        public void Gravar(Caixa objeto)
        {
            if (objeto.id > 0)
            {
                db.CAIXA.Update(objeto);
            }
            else
            {
                db.CAIXA.Add(objeto);
            }
            db.SaveChanges();
        }

        public List<Caixa> PesquisarPorData(DateTime velha, DateTime nova)
        {
            return db.CAIXA.Where(a => a.data >= velha && a.data <= nova).ToList();
        }

        public string Delete(Caixa objeto)
        {
            db.CAIXA.Remove(objeto);
            db.SaveChanges();
            return "excluído com sucesso";
        }

        public Caixa PesquisarId(long id)
        {
            return db.CAIXA.Where(a => a.id == id).FirstOrDefault();
        }

        public List<Caixa> Pesquisar(DateTime query)
        {
            return db.CAIXA.Where(a => a.data == query).ToList();
        }

        public decimal CaixaInicial()
        {
            decimal soma = db.CAIXA.Sum(c => c.valor);
            return soma;
        }
    }
}
