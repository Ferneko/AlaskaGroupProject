import React, { Component } from "react";
import Layout from "../Layout/Layout";
import { Link } from "react-router-dom";
import Conexao from "../Conexao/Conexao";

export default class ListaRelatorioEstoque extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ListaRelatorioEstoque: [],
      query: "",
      erro: null,
    };
    this.pesquisar = this.pesquisar.bind(this);
    this.delete = this.delete.bind(this);
    this.atualizaQuery = this.atualizaQuery.bind(this);
  }

  atualizaQuery(e) {
    this.setState({ query: e.target.value });
  }

  componentDidMount() {
    Conexao.get("/Estoque").then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioEstoque: dados });
      }
    });
  }

  pesquisar(e) {
    console.log(this.state.query);
    var data = this.state.query;
    Conexao.get("/Estoque/PesquisarEstoque/" + data).then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioEstoque: dados });
      }
    });
  }

  delete(e) {
    Conexao.delete("/Estoque", {
      params: { id: e.target.dataset.objeto },
    }).then((resposta) => {
      console.log(resposta.data);
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioEstoque: dados });
      }
    });
    Conexao.get("/Estoque").then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioEstoque: dados });
      }
    });
  }

  render() {
    return (
      <Layout>
        {this.state.erro != null ? (
          <div
            className="alert alert-danger alert-dismissible fade show"
            role="alert"
          >
            {this.state.erro}
            <button
              type="button"
              onClick={() => this.setState({ erro: null })}
              className="close"
              data-dismiss="alert"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
        ) : (
          ""
        )}

        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">Pesquisar</div>
              <div className="card-body">
                <div className="row">
                  <div className="col-2">
                    <Link to="/CadastroEstoque" className="btn btn-success">
                      Novo Estoque
                    </Link>
                  </div>
                  <div className="col-10">
                    <div className="input-group">
                      <input
                        type="text"
                        className="form-control"
                        placeholder="Digite aqui sua pesquisa"
                        onChange={this.atualizaQuery}
                        aria-label="Digite aqui sua pesquisa"
                        aria-describedby="basic-addon2"
                      />
                      <div className="input-group-append">
                        <button
                          className="btn btn-primary"
                          type="button"
                          onClick={this.pesquisar}
                        >
                          Pesquisar
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <br />
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-body">
                <table className="table table-houver">
                  <thead>
                    <tr>
                      <th>Id</th>
                      <th>Data</th>
                      <th>Tipo</th>
                      <th>Tipo da Mov</th>
                      <th>Casquinha Id</th>
                      <th>Quant de Casquinha</th>
                      <th>Adicional Id</th>
                      <th>Quant de Adicional</th>
                      <th>Acompanhamento Id</th>
                      <th>Quant de Acompanhamento</th>
                      <th>Sabores Id</th>
                      <th>Quant de Sabores</th>
                    </tr>
                  </thead>
                  <tbody>
                    {this.state.ListaRelatorioEstoque.map((item) => (
                      <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.data}</td>
                        <td>{item.tipo}</td>
                        <td>{item.tipoMovimentacao}</td>
                        <td>{item.casquinhaid}</td>
                        <td>{item.quantidadeCasquinha}</td>
                        <td>{item.adicionalid}</td>
                        <td>{item.quantidadeAdicional}</td>
                        <td>{item.acompanhamentoid}</td>
                        <td>{item.quantidadeAcompanhamento}</td>
                        <td>{item.saboresid}</td>
                        <td>{item.quantidadeSabores}</td>

                        <td>
                          <Link key={item.id} to={{ pathname: "/EditarEstoque/" + item.id }} className="btn btn-warning"> {" "} Editar{" "}</Link>
                        </td>

                        <td>
                          <button className="btn btn-danger" onClick={this.delete} data-objeto={item.id}> {" "} Excluir{" "} </button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </Layout>
    );
  }
}
