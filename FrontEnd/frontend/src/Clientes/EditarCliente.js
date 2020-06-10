import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";
import { Link } from "react-router-dom";

export default class EditarCliente extends Component {
  constructor(props) {
    super(props);

    //console.log(props);
    //console.log(this.props.match.params.id);
    this.state = {
      id: this.props.match.params.id,
      nome: "",
      cpf: "",
      telefone: "",
      endereco: "",
      bairro: "",
      cep: "",
      cidade: "",
      estado: "",
      ativo: true,
      erro: null,
    };

    this.setNome = this.setNome.bind(this);
    this.setCpf = this.setCpf.bind(this);
    this.setTelefone = this.setTelefone.bind(this);
    this.setEndereco = this.setEndereco.bind(this);
    this.setBairro = this.setBairro.bind(this);
    this.setCep = this.setCep.bind(this);
    this.setCidade = this.setCidade.bind(this);
    this.setEstado = this.setEstado.bind(this);
    this.setAtivo = this.setAtivo.bind(this);
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
  }

  componentDidMount() {
    Conexao.get("/Cliente/" + this.state.id).then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({
          id: dados.id,
          nome: dados.nome,
          cpf: dados.cpf,
          telefone: dados.telefone,
          endereco: dados.endereco,
          bairro: dados.bairro,
          cep: dados.cep,
          cidade: dados.cidade,
          estado: dados.estado,
          ativo: dados.ativo,
        });
      }
    });
  }

  setNome(e) {
    this.setState({
      nome: e.target.value,
    });
  }

  setCpf(e) {
    this.setState({
      cpf: e.target.value,
    });
  }
  setTelefone(e) {
    this.setState({
      telefone: e.target.value,
    });
  }
  setEndereco(e) {
    this.setState({
      endereco: e.target.value,
    });
  }
  setBairro(e) {
    this.setState({
      bairro: e.target.value,
    });
  }
  setCep(e) {
    this.setState({
      cep: e.target.value,
    });
  }
  setCidade(e) {
    this.setState({
      cidade: e.target.value,
    });
  }
  setEstado(e) {
    this.setState({
      estado: e.target.value,
    });
  }
  setAtivo(e) {
    this.setState({
      ativo: e.target.value === "true" ? true : false,
    });
  }
  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Cliente", {
      id: this.state.id,
      nome: this.state.nome,
      cpf: this.state.cpf,
      telefone: this.state.telefone,
      endereco: this.state.endereco,
      bairro: this.state.bairro,
      cep: this.state.cep,
      cidade: this.state.cidade,
      estado: this.state.estado,
      ativo: this.state.ativo,
    })
      .then((resposta) => {
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          //alert("deu");
          this.props.history.push("/ListaClientes");
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
        
        <div className="row" id="titulo-editar-cliente">
          <div className="form-group col-md-12">
              <h4>Edição de Clientes</h4>
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
                <label> CPF </label>
                <input
                  type="text"
                  className="form-control"
                  id="cpf"
                  name="cpf"
                  value={this.state.cpf}
                  onChange={this.setCpf}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Telefone </label>
                <input
                  type="text"
                  className="form-control"
                  name="telefone"
                  value={this.state.telefone}
                  onChange={this.setTelefone}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Endereço </label>
                <input
                  type="text"
                  className="form-control"
                  name="endereco"
                  value={this.state.endereco}
                  onChange={this.setEndereco}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Bairro </label>
                <input
                  type="text"
                  className="form-control"
                  name="bairro"
                  value={this.state.bairro}
                  onChange={this.setBairro}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> CEP </label>
                <input
                  type="text"
                  className="form-control"
                  name="cep"
                  value={this.state.cep}
                  onChange={this.setCep}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Cidade </label>
                <input
                  type="text"
                  className="form-control"
                  name="cidade"
                  value={this.state.cidade}
                  onChange={this.setCidade}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <label> Estado </label>
                <input
                  type="text"
                  className="form-control"
                  name="estado"
                  value={this.state.estado}
                  onChange={this.setEstado}
                />
              </div>
            </div>
            <div class="row">
              <div className="form-group col-md-12">
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
            </div>
            <div class="row">
              <div className="form-group col-md-12">
                <button className="btn btn-success" onClick={this.enviarParaBackEnd}> Salvar </button>
                <Link to={{pathname: "/ListaClientes"}} className="btn btn-danger" id="btn-danger-editar-cliente">Cancelar</Link>
              </div>
            </div>
          </div>
        </div>
      </Layout>
    );
  }
}
