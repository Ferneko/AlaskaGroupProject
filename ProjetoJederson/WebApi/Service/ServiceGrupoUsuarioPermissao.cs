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
        private ServicePermissao servicePermissao;

        public ServiceGrupoUsuarioPermissao(Contexto db)
        {
            dao = new DaoGrupoUsuarioPermissao(db);
            servicePermissao = new ServicePermissao(db);
        }

        public void Delete(long idPermissao, long idGrupoUsuario)
        {
            GrupoUsuarioPermissao objeto = PesquisarIdPermissaoIdGrupoUsuario(idPermissao, idGrupoUsuario);

            if (objeto != null)
            {
                dao.Delete(objeto);
            }
            else
            {
                throw new Exception("Não encontrado. Erro ao deletar");
            }
        }

        private GrupoUsuarioPermissao PesquisarIdPermissaoIdGrupoUsuario(long idPermissao, long idGrupoUsuario)
        {
            return dao.PesquisarIdPermissaoIdGrupoUsuario(idPermissao, idGrupoUsuario);
        }

        public GrupoUsuarioPermissao Gravar(GrupoUsuarioPermissaoModel objeto)
        {
            GrupoUsuarioPermissao novo = new GrupoUsuarioPermissao();
            novo.grupoUsuarioId = objeto.idGrupoUsuario;
            novo.permissaoId = objeto.idPermissao;
            return dao.Gravar(novo);
        }

        public List<GrupoUsuarioPermissao> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<GrupoUsuarioPermissao> Pesquisar(string texto)
        {
            return dao.Pesquisar(texto);
        }

        public List<GrupoUsuarioPermissaoModel> ListarTodosPorGrupoUsuario(long id)
        {
            List<GrupoUsuarioPermissaoModel> retorno = new List<GrupoUsuarioPermissaoModel>();
            List<GrupoUsuarioPermissao> permissoesGrupo = dao.PesquisarIdGrupoUsuario(id);
          
            foreach (var item in servicePermissao.ListaTodos())
            {
                retorno.Add(new GrupoUsuarioPermissaoModel()
                {
                    idGrupoUsuario = id,
                    idPermissao = item.id,
                    descricao = item.descricao,
                    nome = item.nome,
                    ativo = permissoesGrupo.Where(a => a.id == item.id).Count() == 1 ? true : false
                }) ;
            }

            return retorno;

        }

        public GrupoUsuarioPermissao PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }
    }
}
