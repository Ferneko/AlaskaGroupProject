using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoSabores
    {
        private Contexto db;

        public DaoSabores(Contexto _db)
        {
            db = _db;
        }

       public void Record(Sabores objeto)
       {
        if(objeto.Id == 0)
        {
            db.SABORES.Add(objeto);
                db.SaveChanges();
        }
        else
        {
                db.SABORES.Update(objeto);
                db.SaveChanges();
            }
        
        }

       public List<Sabores> ListaTodosAtivos()
        {
            return db.SABORES.Where(a => a.Ativo == true).ToList();
        }

        public List<Sabores> ListaTodos()
        {
            return db.SABORES.ToList();
        }

        public List<Sabores> Search(string texto)
        {
            return db.SABORES.Where(a => a.Name.Contains(texto)).ToList();
        }
        public Sabores SearchId(long id)
        {
            return db.SABORES.Where(a => a.Id == id).FirstOrDefault();
        }

    }

}
