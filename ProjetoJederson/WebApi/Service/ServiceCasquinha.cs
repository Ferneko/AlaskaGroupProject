using Microsoft.AspNetCore.Mvc;
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
        public string Delete(long id)
        {
            Casquinha objeto = SearchId(id);

            if (objeto != null)
            {
                return dao.Delete(objeto);
            }
            else
            {
                return "erro 404 não encontrado";
            }
        }
        public Casquinha Record(Casquinha objeto)
        {

            if (string.IsNullOrEmpty(objeto.Name))
            {
                throw new Exception("Nome não pode estar em branco");
            }

            if (Pesquisar(objeto.Name).Count > 0)
            {
                throw new Exception("Nome já cadastrado");
            }
            return dao.Record(objeto);
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

        public Casquinha SearchId(long id)
        {
            return dao.SearchId(id);
        }

        public List<Casquinha> Pesquisar(string texto)
        {
            return dao.Search(texto);
        }
    }
}

