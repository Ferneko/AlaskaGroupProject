import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

export default class EditarPermissao extends Component {
  constructor(props) {
    super(props);
    this.state = {
      id: this.props.match.params.id,
      role: "",
      descricao: "",
      nome: "",
    };
    this.setId = this.setId.bind(this);
    this.setRole = this.setRole.bind(this);
    this.setDescricao = this.setDescricao.bind(this);
    this.setNome = this.setNome.bind(this);
  }

  componentDidMount() {
    Conexao.get("/Permissao/" + this.state.id).then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({
          id: dados.id,
          role: dados.role,
          descricao: dados.descricao,
          nome: dados.nome,
        });
      }
    });
  }

  setId(e) {
    this.setState({
      id: e.target.value,
    });
  }

  setRole(e) {
    this.setState({
     role: e.target.value,
    });
  }

  setDescricao(e) {
    this.setState({
     descricao: e.target.value,
    });
  }

  setNome(e) {
    this.setState({
     nome: e.target.value,
    });
  }

  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Permissao", {
      id: this.state.id,
      role: this.state.role,
      descricao: this.state.descricao,
      nome: this.state.nome,
    })
    .then((resposta) => {
      const dados = resposta.data;
      console.log(dados.erro);
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        //alert("deu");
        this.props.history.push("/ListaRelatorioPermissao");
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

        <div className="row" id="titulo-permissao">
            <h4>Permissão</h4>
        </div>

        <br></br>

        <div className="row">
          <div className="form-group col-md-3">
            <label>Id</label>
            <input
              type="text"
              readOnly={true}
              className="form-control"
              name="id"
              value={this.state.id}
            />
          </div>

          <div className="form-group col-md-3">
            <label>Role</label>
            <input
              type="text"
              className="form-control"
              name="role"
              value={this.state.role}
              onChange={this.setRole}
            />
          </div>
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
            <label>Nome</label>
            <input
              type="text"
              className="form-control"
              name="nome"
              value={this.state.nome}
              onChange={this.setNome}
            />
          </div>

        <br></br>

        <div className="row">
          <button className="btn btn-success" onClick={this.enviarParaBackEnd}> Salvar </button>
        </div>
      </Layout>
    );
  }
}
