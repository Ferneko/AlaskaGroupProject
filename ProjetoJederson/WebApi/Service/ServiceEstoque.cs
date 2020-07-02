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
        private ServiceProduto serviceProduto;

        public ServiceEstoque(Contexto db)
        {
            dao = new DaoEstoque(db);

            serviceProduto = new ServiceProduto(db);

        }

        public decimal saldoCasquinha(long idCasquinha)
        {
            return dao.qtdCasquinha(idCasquinha);
        }

        public void Gravar(Estoque objeto)
        {
            if (objeto.tipoMovimentacao == 0)
            {
                decimal teste = dao.qtdCasquinha(objeto.casquinhaId);
                if (teste < (objeto.quantidadeCasquinha*-1))
                {
                    throw new Exception("Quantidade não disponivel desta Casquinha");
                }

                if (dao.qtdAdicional(objeto.adicionalId) < (objeto.quantidadeAdicional * -1))
                {
                    throw new Exception("Quantidade não disponivel deste Adicional");
                }

                if (dao.qtdAcompanhamento(objeto.acompanhamentoId) < (objeto.quantidadeAcompanhamento * -1))
                {
                    throw new Exception("Quantidade não disponivel deste Acompanhamento");
                }

                if (dao.qtdsSabores(objeto.saboresId) < (objeto.quantidadeSabores * -1))
                {
                    throw new Exception("Quantidade não disponivel deste sabor");
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

      

        public ModelMovimentacaoEstoque novaEntrada()
        {
            ModelMovimentacaoEstoque retorno = new ModelMovimentacaoEstoque();
            retorno.todasCasquinhas = serviceProduto.serviceCasquinha.ListaTodos();
            retorno.todosSabores = serviceProduto.serviceSabores.ListaTodos();
            retorno.todosAdicionais = serviceProduto.serviceAdicional.ListaTodos();
            retorno.todosAcompanhamentos = serviceProduto.serviceAcompanhamentos.ListaTodos();

            return retorno;
        }

        public void saidaPorVenda(Venda venda)
        {
            
            foreach (var item in venda.listaItens)
            {
                Estoque saidaPorVenda = new Estoque();
                saidaPorVenda.tipoMovimentacao = 0;
                saidaPorVenda.data = venda.dataVenda;

                if (item.acompanhamentosId > 0)
                {
                    saidaPorVenda.acompanhamentoId = item.acompanhamentosId;
                    saidaPorVenda.quantidadeAcompanhamento = -1;
                }
                else
                {
                    saidaPorVenda.acompanhamentoId = serviceProduto.serviceAcompanhamentos.ListaTodos().FirstOrDefault().id;
                    saidaPorVenda.quantidadeAcompanhamento = 0;
                }

                if (item.adicionalId > 0)
                {
                    saidaPorVenda.adicionalId = item.adicionalId;
                    saidaPorVenda.quantidadeAdicional = -1;
                }
                else
                {
                    saidaPorVenda.adicionalId = serviceProduto.serviceAdicional.ListaTodos().FirstOrDefault().id;
                    saidaPorVenda.quantidadeAdicional = 0;
                }

                if (item.casquinhaId > 0)
                {
                    saidaPorVenda.casquinhaId = item.casquinhaId;
                    saidaPorVenda.quantidadeCasquinha = -1;
                }
                else
                {
                    saidaPorVenda.casquinhaId = serviceProduto.serviceCasquinha.ListaTodos().FirstOrDefault().Id;
                    saidaPorVenda.quantidadeCasquinha = 0;
                }

                if (item.saborId > 0)
                {
                    saidaPorVenda.saboresId = item.saborId;
                    saidaPorVenda.quantidadeSabores = -1;
                }
                else
                {
                    saidaPorVenda.saboresId = serviceProduto.serviceSabores.ListaTodos().FirstOrDefault().Id;
                    saidaPorVenda.quantidadeSabores = 0;
                }

                Gravar(saidaPorVenda);
            }
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
