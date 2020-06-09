import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

export default class CadastroAcompanhamentos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      imagem: "",
      id: "",
      nome: "",
      descricao: "",
      valor: "",
      ativo: true,
      erro: null,
    };

    this.setImagem = this.setImagem.bind(this);
    this.setId = this.setId.bind(this);
    this.setNome = this.setNome.bind(this);
    this.setDescricao = this.setDescricao.bind(this);
    this.setValor = this.setValor.bind(this);
    this.setAtivo = this.setAtivo.bind(this);
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
  }

  setId(e) {
    this.setState({
      id: e.target.value,
    });
  }
  setImagem(e) {
    this.setState({
      imagem: e.target.value,
    });
  }
  setNome(e) {
    this.setState({
      nome: e.target.value,
    });
  }
  setDescricao(e) {
    this.setState({
      descricao: e.target.value,
    });
  }
  setValor(e) {
    this.setState({
      valor: e.target.value,
    });
  }
  setAtivo(e) {
    this.setState({
      ativo: e.target.value === "true" ? true : false,
    });
  }

  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Acompanhamentos", {
      imagem: this.state.imagem,
      nome: this.state.nome,
      descricao: this.state.descricao,
      valor: Number(this.state.valor),
      ativo: Boolean(this.state.ativo),
    })
      .then((resposta) => {
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          //alert("deu");
          this.props.history.push("/ListaAcompanhamentos");
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }

  render() {
    return (
      <Layout>
          {this.state.erro != null ? (<div className="alert alert-danger alert-dismissible fade show"
            role="alert">
            {this.state.erro}
            <button
              type="button"
              onClick={() => this.setState({ erro: null })}
              className="close"
              data-dismiss="alert"
              aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
        ):("")}

        <div className="row" id="titulo-cadastro-acompanhamento">
          <div className="form-group col-md-12">
              <h4>Cadastro de Acompanhamentos</h4>
          </div>
        </div>

        <div className="row">
          <div className="col-4"></div>
          <div className="col-4">
            <div class="row">
              <div className="form-group col-md-12">
                <label> Imagem </label>
                <input
                  type="text"
                  className="form-control"
                  id="imagem"
                  name="imagem"
                  value={this.state.imagem}
                  onChange={this.setImagem}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label>Nome</label>
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
                <label> Descrição </label>
                <input
                  type="text"
                  className="form-control"
                  id="descricao"
                  name="descricao"
                  value={this.state.descricao}
                  onChange={this.setDescricao}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Valor </label>
                <input
                  type="number"
                  className="form-control"
                  id="valor"
                  name="valor"
                  value={this.state.valor}
                  onChange={this.setValor}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Ativo: </label>
                <select className="form-control" onChange={this.setAtivo}>
                  <option value={true}>Sim</option>
                  <option value={false}>Não</option>
                </select>
              </div>
            </div>
            <div class="row">
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
