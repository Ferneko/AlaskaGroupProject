using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoAdicional
    {

        private Contexto db;

        public DaoAdicional(Contexto _db)
        {
            db = _db;
        }

        public string Delete(Adicional objeto)
        {
            db.ADICIONAIS.Remove(objeto);
            db.SaveChanges();
            return "Adicional excluído com sucesso";
        }

        public Adicional Gravar(Adicional objeto)
        {
            if (objeto.id == 0)
            {
                db.ADICIONAIS.Add(objeto);
               
            }
            else
            {
                db.ADICIONAIS.Update(objeto);
               
            }
            db.SaveChanges();
            return objeto;
        }

        public List<Adicional> ListaTodosAtivos()
        {
            return db.ADICIONAIS.Where(a => a.ativo == true).ToList();
        }

        public List<Adicional> ListaTodos()
        {
            return db.ADICIONAIS.ToList();
        }

        public List<Adicional> Pesquisar(string texto)
        {
            return db.ADICIONAIS.Where(a => a.nome.Contains(texto)).ToList();
        }
        public Adicional PesquisarPorId(long id)
        {
            return db.ADICIONAIS.Where(a => a.id == id).FirstOrDefault();
        }

        internal decimal saldoAdicional(long id)
        {
            decimal adicional = db.ESTOQUE.Where(a => a.adicionalId == id).Sum(c => c.quantidadeAdicional);
            return adicional;
        }
    }
}

