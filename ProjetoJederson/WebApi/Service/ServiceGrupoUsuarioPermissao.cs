using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceGrupoUsuarioPermissao
    {
        private DaoGrupoUsuarioPermissao dao;

        public ServiceGrupoUsuarioPermissao(Contexto db)
        {
            dao = new DaoGrupoUsuarioPermissao(db);
        }

        public List<GrupoUsuarioPermissao> Delete(long id)
        {
            GrupoUsuarioPermissao cliente = PesquisarId(id);

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

        public GrupoUsuarioPermissao Gravar(GrupoUsuarioPermissao objeto)
        {
            return dao.Gravar(objeto);
        }

        public List<GrupoUsuarioPermissao> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<GrupoUsuarioPermissao> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public GrupoUsuarioPermissao PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
