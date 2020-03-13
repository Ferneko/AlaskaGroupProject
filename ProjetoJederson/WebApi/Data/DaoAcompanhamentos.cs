using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class DaoAcompanhamentos
    {
        private Contexto db;
        public DaoAcompanhamentos(Contexto _db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência
            db = _db;
        }

        public void Gravar(Model.Acompanhamentos objeto)
        {
            if (objeto.id == 0)
            {
                db.ACOMPANHAMENTOS.Add(objeto);
                db.SaveChanges();
            }
            else
            {
                db.ACOMPANHAMENTOS.Update(objeto);
                db.SaveChanges();
            }
        }

        public List<Model.Acompanhamentos> ListaTodosAtivos()
        {
            return db.ACOMPANHAMENTOS.Where(a => a.ativo == true).ToList();
        }

        public List<Acompanhamentos> ListaTodos()
        {
            return db.ACOMPANHAMENTOS.ToList();
        }

        public List<Acompanhamentos> Pesquisar(string texto)
        {
            return db.ACOMPANHAMENTOS.Where(a => a.nome.Contains(texto)).ToList();
        }

        public Acompanhamentos PesquisarId(long id)
        {
            return new Acompanhamentos();
        }

    }
}