using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Service
{
    public class ServiceVenda
    {
        private DaoVenda dao;
        private ServiceProduto serviceProduto;
        private ServiceEstoque serviceEstoque;
        private ServiceCaixa serviceCaixa;
        public ServiceVenda(Contexto db)
        {
            dao = new DaoVenda(db);

            serviceProduto = new ServiceProduto(db);
            serviceCaixa = new ServiceCaixa(db);
            serviceEstoque = new ServiceEstoque(db);
        }

        public List<Venda> Delete(long id)
        {
            Venda venda = PesquisarId(id);

            if (venda != null)
            {
                dao.Delete(venda);
                return ListaTodos();
            }
            else
            {
                throw new Exception("Erro ao deleter. Id já deletado");
            }
        }
        public bool Gravar(VendasModel objeto)
        {
            decimal valorTotal = 0;

            Venda venda = new Venda();
            venda.dataVenda = DateTime.Now;
            venda.listaItens = new List<ItensVenda>();

            ItensVenda iten = new ItensVenda();
            iten.casquinhaId = objeto.casquinhaSelecionada.Id;
            iten.saborId = objeto.saborSelecionado.Id;
            iten.valorCasquinha = serviceProduto.serviceCasquinha.PesquisarId(objeto.casquinhaSelecionada.Id).Preco;
            iten.valorSabor = serviceProduto.serviceSabores.SearchId(objeto.saborSelecionado.Id).Price;
            venda.listaItens.Add(iten);
            valorTotal += iten.valorCasquinha + iten.valorSabor;

            foreach (var item in objeto.adicionaisSelecionados)
            {

                ItensVenda itens = new ItensVenda();

                itens.valorAdicional = serviceProduto.serviceAdicional.PesquisarPorId(item.id).valor;
                itens.adicionalId = item.id;

                valorTotal += itens.valorAdicional;
                venda.listaItens.Add(itens);
            }

            foreach (var item in objeto.acompanhamentosSelecionados)
            {
                ItensVenda itens = new ItensVenda();

                itens.valorAcompanhamentos = serviceProduto.serviceAcompanhamentos.PesquisarId(item.id).valor;
                itens.acompanhamentosId = item.id;

                valorTotal += itens.valorAcompanhamentos;
                venda.listaItens.Add(itens);
            }

            venda.valorTotal = valorTotal;
            bool ok = dao.Gravar(venda);
            if (ok)
            {
                serviceCaixa.entradaPorVenda(venda);
                serviceEstoque.saidaPorVenda(venda);
            }


            return ok;
        }

        public List<Venda> ListaTodos()
        {
            return dao.ListaTodos();
        }

        public Venda PesquisarId(long id)
        {
            return dao.PesquisarId(id);
        }

        public VendasModel Modelo()
        {
            VendasModel retorno = new VendasModel();
            retorno.listaAcompanhamentos = serviceProduto.serviceAcompanhamentos.ListaTodosAtivosEmEstoque();
            retorno.listaAdicionais = serviceProduto.serviceAdicional.ListaTodosAtivosEmEstoque();
            retorno.listaCasquinhas = serviceProduto.serviceCasquinha.ListaTodosAtivosEmEstoque();
            retorno.listaSabores = serviceProduto.serviceSabores.ListaTodosAtivosEmEstoque();
            return retorno;
        }
    }
}
