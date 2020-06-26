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
        private ServiceGrupoUsuario serviceGrupoUsuario;
        public ServiceUsuariosGrupoUsuarios(Contexto db)
        {
            dao = new DaoUsuariosGrupoUsuarios(db);
            serviceGrupoUsuario = new ServiceGrupoUsuario(db);
        }

        public List<UsuariosGrupoUsuariosModel> ListarTodosPorUsuarioId(long usuarioId)
        {
            List<UsuariosGrupoUsuariosModel> retorno = new List<UsuariosGrupoUsuariosModel>();
            List<UsuariosGrupoUsuarios> gruposDoUsuario = dao.PesquisarIdPorUsuarioId(usuarioId);

            foreach (var item in serviceGrupoUsuario.ListaTodos())
            {
                retorno.Add(new UsuariosGrupoUsuariosModel()
                {
                    idUsuario = usuarioId,
                    idGrupoUsuario = item.id,
                    nome = item.nome,
                    ativo = gruposDoUsuario.Where(a => a.grupoUsuarioId == item.id).Count() == 1 ? true : false
                });
            }

            return retorno;
        }

        public void Delete(long idGrupoUsuario, long idUsuario)
        {
            UsuariosGrupoUsuarios objeto = PesquisarPermissaoIdUsuarioId(idUsuario, idGrupoUsuario);

            if (objeto != null)
            {
                dao.Delete(objeto);
               
            }
            else
            {
                throw new Exception("Não encontrado");
            }
        }

        private UsuariosGrupoUsuarios PesquisarPermissaoIdUsuarioId(long idUsuario, long idGrupoUsuario)
        {
            return dao.PesquisarIdPorUsuarioIdGrupoUsuaioId(idUsuario,idGrupoUsuario);
        }

        public UsuariosGrupoUsuarios Gravar(UsuariosGrupoUsuariosModel objeto)
        {
            UsuariosGrupoUsuarios novo = new UsuariosGrupoUsuarios();
            novo.usuarioId = objeto.idUsuario;
            novo.grupoUsuarioId = objeto.idGrupoUsuario;
            return dao.Gravar(novo);
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
