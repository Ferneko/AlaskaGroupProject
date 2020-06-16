using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceUsuariosGrupoUsuarios
    {
        private DaoUsuariosGrupoUsuarios dao;

        public ServiceUsuariosGrupoUsuarios(Contexto db)
        {
            dao = new DaoUsuariosGrupoUsuarios(db);
        }

        public List<UsuariosGrupoUsuarios> Delete(long id)
        {
            UsuariosGrupoUsuarios cliente = PesquisarId(id);

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

        public UsuariosGrupoUsuarios Gravar(UsuariosGrupoUsuarios objeto)
        {
            return dao.Gravar(objeto);
        }

        public List<UsuariosGrupoUsuarios> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<UsuariosGrupoUsuarios> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public UsuariosGrupoUsuarios PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
