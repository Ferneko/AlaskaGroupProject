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

        public string Delete(Acompanhamentos objeto)
        {
            db.ACOMPANHAMENTOS.Remove(objeto);
            db.SaveChanges();
            return "Acompanhamentos excluído com sucesso";
        }

        public Acompanhamentos Gravar(Acompanhamentos objeto)
        {
            if (objeto.id == 0)
            {
                db.ACOMPANHAMENTOS.Add(objeto);
              
            }
            else
            {
                db.ACOMPANHAMENTOS.Update(objeto);
               
            }
            db.SaveChanges();
            return objeto;
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
            return db.ACOMPANHAMENTOS.Where(a => a.id == id).FirstOrDefault();

        }

        public List<Acompanhamentos> PesquisarTodos(string imagem, long id, string nome, string descricao, decimal valor, bool ativo)
        {
            return db.ACOMPANHAMENTOS.Where(a => a.imagem == imagem || a.id == id || a.nome.Contains(nome) || a.descricao.Contains(descricao) || a.valor == valor).ToList();
        }
    }
}