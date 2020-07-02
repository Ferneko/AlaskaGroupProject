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
        private ServicePermissao servicePermissao;
        public ServiceUsuariosPermissao(Contexto db)
        {
            dao = new DaoUsuariosPermissao(db);
            servicePermissao = new ServicePermissao(db);
        }

        public void Delete(long idUsuario, long idPermissao)
        {
            UsuarioPermissao objeto = PesquisarPermissaoIdUsuarioId(idUsuario, idPermissao);

            if (objeto != null)
            {
                dao.Delete(objeto);
               
            }
            else
            {
                //throw new Exception("Não encontrado. Erro ao deletar");
            }
        }

        private UsuarioPermissao PesquisarPermissaoIdUsuarioId(long idUsuario, long idPermissao)
        {
            return dao.PesquisarPermissaoIdUsuarioId(idUsuario, idPermissao);
        }

        public UsuarioPermissao Gravar(UsuarioPermissaoModel objeto)
        {
            UsuarioPermissao novo = new UsuarioPermissao();
            novo.usuarioId = objeto.idUsuario;
            novo.permissaoId = objeto.idPermissao;
            return dao.Gravar(novo);
        }

        public List<UsuarioPermissaoModel> ListarTodosPorUsuarioId(long usuarioId)
        {
            List<UsuarioPermissaoModel> retorno = new List<UsuarioPermissaoModel>();
            List<UsuarioPermissao> permissoesGrupo = dao.PesquisarIdPorUsuarioId(usuarioId);

            foreach (var item in servicePermissao.ListaTodos())
            {
                retorno.Add(new UsuarioPermissaoModel()
                {
                    idUsuario = usuarioId,
                    idPermissao = item.id,
                    descricao = item.descricao,
                    nome = item.nome,
                    ativo = permissoesGrupo.Where(a => a.permissaoId == item.id).Count() == 1 ? true : false
                });
            }

            return retorno;
        }

        public List<Permissao> ListarPermissoesUsuario(long usuarioId)
        {
            List<Permissao> retorno = new List<Permissao>();

            foreach (var item in dao.PesquisarIdPorUsuarioId(usuarioId))
            {
                retorno.Add(item.permissao);
            }
            return retorno; 
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
