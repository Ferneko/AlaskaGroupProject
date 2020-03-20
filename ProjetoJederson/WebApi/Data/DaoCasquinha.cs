using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoCasquinha
    {
        private Contexto db;

        public DaoCasquinha(Contexto _db)
        {
            db = _db;
        }

        public void Record(Casquinha objeto) 
        { 
           if(objeto.Id==0)
            {
                db.CASQUINHA.Add(objeto);
                db.SaveChanges();
            }
           else
            {
                db.CASQUINHA.Update(objeto);
                db.SaveChanges();
            }
        }

        public List<Casquinha> ListAllActives() 
        {
            return db.CASQUINHA.Where(a => a.Actives == true).ToList();
        }

        public List<Casquinha> ListAll()
        {
            return db.CASQUINHA.ToList();
        }

        internal List<Casquinha> SearchId(long Id)
        {
            throw new NotImplementedException();
        }

        internal List<Casquinha> Search(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Casquinha> SearchId(int Id) 
        {
            return db.CASQUINHA.Where(a => a.Id==Id).ToList();

        }

        public List<Casquinha> SearchAll(int Id, string Name, string Type, decimal Price)
        {
            return db.CASQUINHA.Where(a => a.Id== Id || a.Name.Contains(Name) || a.Type.Contains(Type) || a.Price == Price).ToList();

        }

       
    }

    
   
}
