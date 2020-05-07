using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoCliente
    {
        private Contexto db;
        public DaoCliente(Contexto _db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            db = _db;
        }

        public Cliente Gravar(Cliente objeto)
        {
            if (objeto.id == 0)
            {
                db.CLIENTES.Add(objeto);
            }
            else
            {
                db.CLIENTES.Update(objeto);
            }
            db.SaveChanges();
            return objeto;
        }

        public string Delete(Cliente objeto)
        {
            db.CLIENTES.Remove(objeto);
            db.SaveChanges();
            return "Cliente excluído com sucesso";
        }

        public List<Cliente> ListaTodosAtivos()
        {
            return db.CLIENTES.Where(a => a.ativo == true).ToList();
        }

        public List<Cliente> ListaTodos()
        {
            return db.CLIENTES.ToList();
        }

        public List<Cliente> Pesquisar(string texto)
        {
            return db.CLIENTES.Where(a => texto.Contains(a.id.ToString()) || a.nome.Contains(texto) || a.cpf.Contains(texto)).ToList();
        }

        public Cliente PesquisarId(long id)
        {
            return db.CLIENTES.Where(a => a.id == id).FirstOrDefault();
        }
    }
}
