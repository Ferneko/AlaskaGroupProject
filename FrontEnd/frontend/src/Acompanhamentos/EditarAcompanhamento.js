import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

export default class EditarAcompanhamento extends Component {
  constructor(props) {
    super(props);
    this.state = {
      id: this.props.match.params.id,
      imagem: "",
      nome: "",
      descricao: "",
      valor: "",
      ativo: true,
      erro: null,
    };
    this.setId = this.setId.bind(this);
    this.setImagem = this.setImagem.bind(this);
    this.setNome = this.setNome.bind(this);
    this.setDescricao = this.setDescricao.bind(this);
    this.setValor = this.setValor.bind(this);
    this.setAtivo = this.setAtivo.bind(this);
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
  }

  componentDidMount() {
    Conexao.get("/Acompanhamentos/" + this.state.id).then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({
          id: dados.id,
          imagem: dados.imagem,
          nome: dados.nome,
          descricao: dados.descricao,
          valor: dados.valor,
          ativo: dados.ativo,
        });
      }
    });
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
      id: this.state.id,
      imagem: this.state.imagem,
      nome: this.state.nome,
      descricao: this.state.descricao,
      valor: Number(this.state.valor),
      ativo: this.state.ativo,
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

        <div className="col-4" />
        <div className="col-4">
          <div className="form-group">
            <label>Id</label>
            <input
              type="text"
              readOnly={true}
              className="form-control"
              name="id"
              value={this.state.id}
            />
          </div>

          <div className="form-group">
            <label>Imagem</label>
            <input
              type="text"
              className="form-control"
              name="imagem"
              value={this.state.imagem}
              onChange={this.setImagem}
            />
          </div>

          <div className="form-group">
            <label>Nome</label>
            <input
              type="text"
              className="form-control"
              name="nome"
              value={this.state.nome}
              onChange={this.setNome}
            />
          </div>

          <div className="form-group">
            <label>Descrição</label>
            <input
              type="text"
              className="form-control"
              name="descricao"
              value={this.state.descricao}
              onChange={this.setDescricao}
            />
          </div>

          <div className="form-group">
            <label>Valor</label>
            <input
              type="text"
              className="form-control"
              name="valor"
              value={this.state.valor}
              onChange={this.setValor}
            />
          </div>

          <div className="form-group ">
            <label> Ativo: </label>
            <select
              className="form-control"
              value={this.state.ativo}
              onChange={this.setAtivo}
            >
              <option value="true">Sim</option>
              <option value="false">Não</option>
            </select>
          </div>

          <br></br>

          <div className="row">
            <button
              className="btn btn-success"
              onClick={this.enviarParaBackEnd}
            >
              Salvar
            </button>
          </div>
        </div>
      </Layout>
    );
  }
}
