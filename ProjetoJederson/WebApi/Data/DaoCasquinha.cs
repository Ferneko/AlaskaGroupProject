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

        public string Delete(Casquinha objeto)
        {
            db.CASQUINHAS.Remove(objeto);
            db.SaveChanges();
            return "Casquinha excluído com sucesso";
        }

        public Casquinha Record(Casquinha objeto) 
        { 
           if(objeto.Id==0)
            {
                db.CASQUINHAS.Add(objeto);
               
            }
           else
            {
                db.CASQUINHAS.Update(objeto);
                
            }

            db.SaveChanges();
            return objeto;
        }

        public List<Casquinha> ListAllActives() 
        {
            return db.CASQUINHAS.Where(a => a.Actives == true).ToList();
        }

        public List<Casquinha> ListAll()
        {
            return db.CASQUINHAS.ToList();
        }

        public Casquinha SearchId(long Id)
        {
            return db.CASQUINHAS.Where(a => a.Id == Id).FirstOrDefault();

                
        }

        public List<Casquinha> Search(string texto)
        {
            return db.CASQUINHAS.Where(a => texto.Contains(a.Id.ToString()) || a.Name.Contains(texto) || a.Type.Contains(texto) ).ToList();
        }

     

        public List<Casquinha> SearchAll(int Id, string Name, string Type, decimal Price)
        {
            return db.CASQUINHAS.Where(a => a.Id== Id || a.Name.Contains(Name) || a.Type.Contains(Type) || a.Price == Price).ToList();

        }

        internal List<Casquinha> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }

    
   
}
