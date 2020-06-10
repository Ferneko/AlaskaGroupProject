import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";
import { Link } from "react-router-dom";

export default class CadastroUsuario extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nome: "",
      login: "",
      senha: "",
      ativo: true,
      erro: null,
    };

    this.setNome = this.setNome.bind(this);
    this.setLogin = this.setLogin.bind(this);
    this.setSenha = this.setSenha.bind(this);
    this.setAtivo = this.setAtivo.bind(this);
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
  }

  setNome(e) {
    this.setState({
      nome: e.target.value,
    });
  }
  setLogin(e) {
    this.setState({
      login: e.target.value,
    });
  }
  setSenha(e) {
    this.setState({
      senha: e.target.value,
    });
  }
  setAtivo(e) {
    this.setState({
      ativo: e.target.value === "true" ? true : false,
    });
  }

  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Usuarios", {
      nome: this.state.nome,
      login: this.state.login,
      senha: this.state.senha,
      ativo: this.state.ativo,
    })
      .then((resposta) => {
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          //alert("deu");
          this.props.history.push("/ListaUsuarios");
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

        <div className="row" id="titulo-cadastro-usuarios">
          <div className="form-group col-md-12">
            <h4>Cadastro de Usuários</h4>
          </div>
        </div>

        <div className="row">
          <div className="col-4"></div>
            <div className="col-4">
              <div className="row">
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
              <div className="row">
                <div className="form-group col-md-12">
                    <label> Login </label>
                    <input
                      type="text"
                      className="form-control"
                      id="login"
                      name="login"
                      value={this.state.login}
                      onChange={this.setLogin}
                    />
                </div>
              </div>
              <div className="row">
                <div className="form-group col-md-12">
                    <label> Senha </label>
                    <input
                      type="password"
                      className="form-control"
                      name="senha"
                      value={this.state.senha}
                      onChange={this.setSenha}
                    />
                </div>
              </div>
              <div className="row">
                <div className="form-group col-md-12">
                    <label> Ativo: </label>
                    <select
                      value={this.state.ativo}
                      className="form-control"
                      onChange={this.setAtivo}>
                      <option value="true">Sim</option>
                      <option value="false">Não</option>
                    </select>
                </div>
              </div>
              <div className="row">
                <div className="form-group col-md-12">
                  <button className="btn btn-success" onClick={this.enviarParaBackEnd}> Salvar </button>
                  <Link to={{pathname: "/ListaUsuarios"}} className="btn btn-danger" id="btn-danger-cadastro-usuarios">Cancelar</Link>
                </div>
            </div>
          </div>
        </div>
      </Layout>
    );
  }
}
