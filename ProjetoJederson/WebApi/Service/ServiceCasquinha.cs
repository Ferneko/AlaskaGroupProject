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
        public List<Casquinha> Delete(long id)
        {
            Casquinha casquinha = PesquisarId(id);

            if (casquinha != null)
            {
                dao.Delete(casquinha);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Erro ao deleter. Id já deletado");
            }
        }
        public Casquinha Gravar(Casquinha objeto)
        {
          
            return dao.Gravar(objeto);
        }

        public List<Casquinha> ListaTodosAtivos()
        {
            return dao.ListaTodosAtivos();
        }

        public List<Casquinha> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Casquinha> PesquisarTodos(int Id, string Name, string Type, decimal Price)
        {
            return dao.PesquisarTodos(Id, Name, Type, Price);
        }

        public Casquinha PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }

        public List<Casquinha> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public List<Casquinha> ListaTodosAtivosEmEstoque()
        {
            List<Casquinha> retorno = new List<Casquinha>();
            foreach (var item in ListaTodosAtivos())
            {
                if (dao.saldoCasquinha(item.Id) > 0)
                {
                    retorno.Add(item);
                }

            }

            return retorno;
        }
    }
}

