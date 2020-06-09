import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

export default class CadastroCasquinha extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nome: "",
      tipo: "",
      preco: "",
      ativo: true,
      erro: null,
    };

    this.setNome = this.setNome.bind(this);
    this.setTipo = this.setTipo.bind(this);
    this.setPreco = this.setPreco.bind(this);
    this.setAtivo = this.setAtivo.bind(this);
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
  }

  setNome(e) {
    this.setState({
      nome: e.target.value,
    });
  }

  setTipo(e) {
    this.setState({
      tipo: e.target.value,
    });
  }

  setPreco(e) {
    this.setState({
      preco: e.target.value,
    });
  }

  setAtivo(e) {
    this.setState({
      ativo: e.target.value === "true" ? true : false,
    });
  }
  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Casquinha", {
      nome: this.state.nome,
      tipo: this.state.tipo,
      preco: Number(this.state.preco),
      ativo: this.state.ativo,
    })
      .then((resposta) => {
        // console.log('entrou aqui');
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          this.props.history.push("/ListaCasquinha");
        }
      })
      .catch((error) => {
        console.log(error);
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

        <div className="row" id="titulo-cadastro-casquinha">
          <div className="form-group col-md-12">
              <h4>Cadastro de Casquinhas</h4>
          </div>
        </div>

        <div className="row">
          <div className="col-4"></div>
          <div className="col-4">
            <div class="row">
              <div className="form-group col-md-12">
                <label> Nome </label>
                <input
                  type="text"
                  className="form-control"
                  id="nome"
                  name="nome"
                  value={this.state.nome}
                  onChange={this.setNome}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Tipo </label>
                <input
                  type="text"
                  className="form-control"
                  id="tipo"
                  name="tipo"
                  value={this.state.tipo}
                  onChange={this.setTipo}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Preço </label>
                <input
                  type="number"
                  className="form-control"
                  name="preco"
                  value={this.state.preco}
                  onChange={this.setPreco}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Ativo: </label>
                <select
                  className="form-control"
                  value={this.state.ativo}
                  onChange={this.setAtivo}>
                  <option value="true">Sim</option>
                  <option value="false">Não</option>
                </select>
              </div>
            </div>
            <div className="row">
              <div className="form-group col-md-12">
                <button className="btn btn-success" onClick={this.enviarParaBackEnd}> Salvar </button>
              </div>
            </div>
          </div>
        </div>
      </Layout>
    );
  }
}
