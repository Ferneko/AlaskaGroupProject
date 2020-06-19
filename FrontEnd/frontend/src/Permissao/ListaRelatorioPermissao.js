import React, { Component } from "react";
import Layout from "../Layout/Layout";
import { Link } from "react-router-dom";
import Conexao from "../Conexao/Conexao";

export default class ListaRelatorioPermissao extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ListaRelatorioPermissao: [],
      erro: null,
      query: "",
    };
    this.pesquisar = this.pesquisar.bind(this);
    this.delete = this.delete.bind(this);
    this.atualizaQuery = this.atualizaQuery.bind(this);
  }

  atualizaQuery(e) {
    this.setState({ query: e.target.value });
  }

  componentDidMount() {
    Conexao.get("/Permissao").then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioPermissao: dados });
      }
    });
  }

  pesquisar(e) {
    console.log(this.state.query);
    var data = this.state.query;
    Conexao.get("/Permissao/PesquisarPermissao/" + data).then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioPermissao: dados });
      }
    });
  }

  delete(e) {
    Conexao.delete("/Permissao", {
      params: { id: e.target.dataset.objeto },
    }).then((resposta) => {
      console.log(resposta.data);
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioPermissao: dados });
      }
    });
    Conexao.get("/Permissao").then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({ ListaRelatorioPermissao: dados });
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
                    <Link to="/CadastroPermissao" className="btn btn-success"> Nova Permissão </Link>
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
                      <th>Role</th>
                      <th>Descrição</th>
                      <th>Nome</th>
                    </tr>
                  </thead>
                  <tbody>
                    {this.state.ListaRelatorioPermissao.map((item) => (
                      <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.role}</td>
                        <td>{item.descricao}</td>
                        <td>{item.nome}</td>     
                        <td>
                          <Link key={item.id} to={{ pathname: "/EditarPermissao/" + item.id }} className="btn btn-warning"> Editar </Link>
                        </td>    
                        <td>
                          <button className="btn btn-danger" onClick={this.delete} data-objeto={item.id}> Excluir </button>
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
