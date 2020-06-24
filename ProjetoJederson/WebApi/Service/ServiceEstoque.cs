using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceEstoque
    {
        private DaoEstoque dao;
        private ServiceCasquinha serviceCasquinha;
        private ServiceAdicional serviceAdicional;
        private ServiceAcompanhamentos serviceAcompanhamentos;
        private ServiceSabores serviceSabores;

        public ServiceEstoque(Contexto db)
        {
            dao = new DaoEstoque(db);
            serviceAdicional = new ServiceAdicional(db);
            serviceAcompanhamentos = new ServiceAcompanhamentos(db);
            serviceSabores = new ServiceSabores(db);
            serviceCasquinha = new ServiceCasquinha(db);

        }

        public decimal saldoCasquinha(long idCasquinha)
        {
            return dao.qtdCasquinha(idCasquinha);
        }

        public void Gravar(Estoque objeto)
        {
            if (objeto.tipoMovimentacao == 0)
            {
                if (dao.qtdCasquinha(objeto.casquinhaId) > objeto.quantidadeCasquinha)
                {
                    throw new Exception("Quantidade não disponivel desta Casquinha");
                }
                if (dao.qtdAdicional(objeto.id) > objeto.quantidadeAdicional)
                {
                    throw new Exception("Quantidade não disponivel desta Casquinha");
                }
                if (dao.qtdAcompanhamento(objeto.acompanhamentoId) > objeto.acompanhamentoId)
                {
                    throw new Exception("Quantidade não disponivel desta Casquinha");
                }
                if (dao.qtdsSabores(objeto.saboresId) > objeto.saboresId)
                {
                    throw new Exception("Quantidade não disponivel desta Casquinha");
                }


            }


            dao.Gravar(objeto);

        }

        public List<Estoque> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public List<Estoque> PesquisarPorData(DateTime velha, DateTime nova)
        {
            return dao.PesquisarPorData(velha, nova);
        }

        public List<Estoque> Pesquisar(DateTime query)
        {
            return dao.Pesquisar(query);
        }

        public List<Estoque> Delete(long id)
        {
            Estoque objeto = dao.PesquisarId(id);

            if (objeto != null)
            {
                dao.Delete(objeto);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Erro ao deleter. Id já deletado");
            }
        }

        public ModelMovimentacaoEstoque movimentaocao()
        {
            throw new NotImplementedException();
        }

        public ModelMovimentacaoEstoque novaEntrada()
        {
            ModelMovimentacaoEstoque retorno = new ModelMovimentacaoEstoque();
            retorno.todasCasquinhas = serviceCasquinha.ListaTodos();
            retorno.todosSabores = serviceSabores.ListaTodos();
            retorno.todosAdicionais = serviceAdicional.ListaTodos();
            retorno.todosAcompanhamentos = serviceAcompanhamentos.ListaTodos();

            return retorno;
        }


        public decimal saldoCasquinha(long idCasquinha)
        {
            return dao.qtdCasquinha(idCasquinha);
        }
        
          public decimal saldoAcompanhamento(long idAcompanhamento)
        {
            return dao.qtdAcompanhamento(idAcompanhamento);
        }

          
          public decimal saldoAdicional(long idAdicional)
        {
            return dao.qtdAdicional(idAdicional);
        }


          
          public decimal saldoSabores(long idSabores)
        {
            return dao.qtdsSabores(idSabores);
        }

    }
}
