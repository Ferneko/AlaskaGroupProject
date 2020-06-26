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
        private ServiceUsuariosPermissao serviceUsuarioPermissao;
        private ServiceGrupoUsuarioPermissao serviceGrupoUsuarioPermissao;
        public ServiceUsuariosGrupoUsuarios(Contexto db)
        {
            dao = new DaoUsuariosGrupoUsuarios(db);
            serviceGrupoUsuario = new ServiceGrupoUsuario(db);
            serviceUsuarioPermissao = new ServiceUsuariosPermissao(db);
            serviceGrupoUsuarioPermissao = new ServiceGrupoUsuarioPermissao(db);
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
            UsuariosGrupoUsuarios objeto = PesquisarIdPorUsuarioIdGrupoUsuaioId(idUsuario, idGrupoUsuario);

            if (objeto != null)
            {
                
                List<GrupoUsuarioPermissaoModel> listaPermissaoGrupo = serviceGrupoUsuarioPermissao.ListarTodosPorGrupoUsuario(idGrupoUsuario).Where(a => a.ativo == true).ToList();

                foreach (var item in listaPermissaoGrupo)                                                                                     
                {
                    serviceUsuarioPermissao.Delete(idUsuario, item.idPermissao);

                }

                dao.Delete(objeto);
               
            }
            else
            {
                throw new Exception("Não encontrado");
            }
        }

        private UsuariosGrupoUsuarios PesquisarIdPorUsuarioIdGrupoUsuaioId(long idUsuario, long idGrupoUsuario)
        {
            return dao.PesquisarIdPorUsuarioIdGrupoUsuaioId(idUsuario,idGrupoUsuario);
        }

        public UsuariosGrupoUsuarios Gravar(UsuariosGrupoUsuariosModel objeto)
        {
            UsuariosGrupoUsuarios novo = new UsuariosGrupoUsuarios();
            novo.usuarioId = objeto.idUsuario;
            novo.grupoUsuarioId = objeto.idGrupoUsuario;
            dao.Gravar(novo);

            List<UsuarioPermissaoModel> listaPermissoesUsuario = serviceUsuarioPermissao.ListarTodosPorUsuarioId(objeto.idUsuario)                  .Where(a => a.ativo == true).ToList();
            List<GrupoUsuarioPermissaoModel> listaPermissaoGrupo = serviceGrupoUsuarioPermissao.ListarTodosPorGrupoUsuario(objeto.idGrupoUsuario)   .Where(a => a.ativo == true).ToList();
            
            int teste = listaPermissaoGrupo.RemoveAll(a => listaPermissoesUsuario.Any(l => l.idPermissao == a.idPermissao));

            foreach (var item in listaPermissaoGrupo)
            {
                serviceUsuarioPermissao.Gravar(new UsuarioPermissaoModel()
                {
                    idUsuario = objeto.idUsuario,
                    idPermissao = item.idPermissao
                });

            }

            return novo;
               
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
