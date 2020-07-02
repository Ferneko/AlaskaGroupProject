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

        public Casquinha Gravar(Casquinha objeto)
        {
            if (objeto.Id == 0)
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

        public List<Casquinha> ListaTodosAtivos()
        {
            return db.CASQUINHAS.Where(a => a.Ativo == true).ToList();
        }

        public List<Casquinha> ListaTodos()
        {
            return db.CASQUINHAS.ToList();
        }

        public Casquinha PesquisarId(long Id)
        {
            return db.CASQUINHAS.Where(a => a.Id == Id).FirstOrDefault();


        }

        public List<Casquinha> Pesquisar(string texto)
        {
            return db.CASQUINHAS.Where(a => texto.Contains(a.Id.ToString()) || a.Nome.Contains(texto) || a.Tipo.Contains(texto)).ToList();
        }



        public List<Casquinha> PesquisarTodos(int Id, string Nome, string Tipo, decimal Preco)
        {
            return db.CASQUINHAS.Where(a => a.Id == Id || a.Nome.Contains(Nome) || a.Tipo.Contains(Tipo) || a.Preco == Preco).ToList();

        }

        public decimal saldoCasquinha(long id)
        {
            decimal casquinha = db.ESTOQUE.Where(a => a.casquinhaId == id).Sum(c => c.quantidadeCasquinha);
            return casquinha;
        }
    }



}
