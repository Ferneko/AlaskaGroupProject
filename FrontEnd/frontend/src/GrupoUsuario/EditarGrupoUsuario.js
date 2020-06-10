import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";
import { Link } from "react-router-dom";

export default class EditarGrupoUsuario extends Component {
  
  constructor(props) {
    super(props);
    this.state = {
      id: this.props.match.params.id,
      nome: "",
    };
    this.setId = this.setId.bind(this);
    this.setNome = this.setNome.bind(this);
  }

  componentDidMount() {
    Conexao.get("/GrupoUsuario/" + this.state.id).then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({
          id: dados.id,
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

  setNome(e) {
    this.setState({
      nome: e.target.value,
    });
  }

  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/GrupoUsuario", {
      id: this.state.id,
      nome: this.state.nome,
    })
      .then((resposta) => {
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          //alert("deu");
          this.props.history.push("/ListaRelatorioGrupoUsuario");
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

        <div className="row" id="titulo-editar-grupo-usuario">
          <div className="form-group col-md-12">
              <h4>Edição de Grupo Usuário</h4>
          </div>
        </div>

        <div className="row">
          <div className="col-4"></div>
          <div className="col-4">
            <div className="row">
              <div className="form-group col-md-12">
                <label>Id</label>
                <input
                  type="text"
                  readOnly={true}
                  className="form-control"
                  id="id"
                  name="id"
                  value={this.state.SetId}
                />
              </div>
            </div>
            <div className="row">
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
            <div className="row">
              <div className="form-group col-md-12">
                <button className="btn btn-success" onClick={this.enviarParaBackEnd}> Salvar </button>
                <Link to={{pathname: "/ListaRelatorioGrupoUsuario"}} className="btn btn-danger" id="btn-danger-editar-grupo-usuario">Cancelar</Link>
              </div>
            </div>
          </div>
        </div>
      </Layout>
    );
  }
}
