using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class DaoAdicional
    {

        private Contexto db;

        public DaoAdicional(Contexto _db)
        {
            db = _db;
        }

        public void Gravar(Adicional objeto)
        {
            if (objeto.Id == 0)
            {
                db.ADICIONAL.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.ADICIONAL.Update(objeto);
                db.SaveChanges();
            }

        }

        public List<Adicional> ListaTodosAtivos()
        {
            return db.ADICIONAL.Where(a => a.Ativo == true).ToList();
        }

        public List<Adicional> ListaTodos()
        {
            return db.ADICIONAL.ToList();
        }

        public List<Adicional> Pesquisar(string texto)
        {
            return db.ADICIONAL.Where(a => a.Name.Contains(texto)).ToList();
        }
        public Adcional PesquisarPorId(long id)
        {
            return db.ADICIONAL.Where(a => a.Id == id).FirstOrDefault();
        }

    }
}

