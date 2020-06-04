using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceGrupoUsuario
    {
        private DaoGrupoUsuario dao;

        public ServiceGrupoUsuario(Contexto db)
        {
            //Aqui vai a instancia do banco de dados passada por Injeção de Dependência

            dao = new DaoGrupoUsuario(db);
        }

        public List<GrupoUsuario> Delete(long id)
        {
            GrupoUsuario cliente = PesquisarId(id);

            if (cliente != null)
            {
                dao.Delete(cliente);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Não encontrado");
            }
        }

        public GrupoUsuario Gravar(GrupoUsuario objeto)
        {
            if (string.IsNullOrEmpty(objeto.nome))
            {

                throw new Exception("Nome não pode estar em branco");

            }

            return dao.Gravar(objeto);
        }

        public List<GrupoUsuario> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<GrupoUsuario> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public GrupoUsuario PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
