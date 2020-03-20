using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceCasquinha
    {
        private DaoCasquinha dao;

        public ServiceCasquinha(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência

            dao = new DaoCasquinha(db);
        }

        public void Record(Casquinha objeto)
        {
            dao.Record(objeto);
        }

        public List<Casquinha>ListAllActives()
        {
            return dao.ListAllActives();
        }

        public List<Casquinha> ListAll()
        {
            return dao.ListAll();
        }


        public List<Casquinha> SearchAll(int Id, string Name, string Type, decimal Price)
        {
            return dao.SearchAll(Id, Name, Type, Price);

        }
    }
}

