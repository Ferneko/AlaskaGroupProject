using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceUsuariosPermissao
    {
        private DaoUsuariosPermissao dao;

        public ServiceUsuariosPermissao(Contexto db)
        {
            dao = new DaoUsuariosPermissao(db);
        }

        public List<UsuarioPermissao> Delete(long id)
        {
            UsuarioPermissao cliente = PesquisarId(id);

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

        public UsuarioPermissao Gravar(UsuarioPermissao objeto)
        {
            return dao.Gravar(objeto);
        }

        public List<UsuarioPermissao> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<UsuarioPermissao> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public UsuarioPermissao PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
