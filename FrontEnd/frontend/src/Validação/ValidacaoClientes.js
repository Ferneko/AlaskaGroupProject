import React from "react";
import ReactDOM from "react-dom";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

class ValidacaoClientes extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
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

    this.handleChange.setNome = this.setNome.bind(this);
    this.handleChange.setCpf = this.setCpf.bind(this);
    this.handleChange.setTelefone = this.setTelefone.bind(this);
    this.handleChange.setEndereco = this.setEndereco.bind(this);
    this.handleChange.setBairro = this.setBairro.bind(this);
    this.handleChange.setCep = this.setCep.bind(this);
    this.handleChange.setCidade = this.setCidade.bind(this);
    this.handleChange.setEstado = this.setEstado.bind(this);
    this.handleChange.setAtivo = this.setAtivo.bind(this);
  }

  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Cliente", {
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

  handleChange(event) {
    this.setState({ nome:  event.target.nome.replace(/[^\d\s-/]/g,  "") });
    this.setState({ cpf:   event.target.cpf.replace(/[^\d\s-/]/g,   "") });
    this.setState({ telefone: event.target.telefone.replace(/[^\d\s-/]/g, "") });
    this.setState({ endereco: event.target.endereco.replace(/[^\d\s-/]/g, "") });
    this.setState({ bairro: event.target.bairro.replace(/[^\d\s-/]/g, "") });
    this.setState({ cep: event.target.cep.replace(/[^\d\s-/]/g, "") });
    this.setState({ cidade: event.target.cidade.replace(/[^\d\s-/]/g, "") });
    this.setState({ estado: event.target.estado.replace(/[^\d\s-/]/g, "") });
    this.setState({ ativo: event.target.ativo.replace(/[^\d\s-/]/g, "") });
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

        <div className="col-4"></div>
        <div class="row">
          <div className="form-group" class="col-md-4">
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
          <div className="form-group" class="col-md-4">
            <label>CPF</label>
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
          <div className="form-group" class="col-md-4">
            <label>Telefone</label>
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
          <div className="form-group" class="col-md-4">
            <label>Endereço</label>
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
          <div className="form-group" class="col-md-4">
            <label>Bairro</label>
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
          <div className="form-group" class="col-md-4">
            <label>CEP</label>
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
          <div className="form-group" class="col-md-4">
            <label>Cidade</label>
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
          <div className="form-group" class="col-md-4">
            <label>Estado</label>
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
          <div className="form-group" class="col-md-4">
            <label>Ativo:</label>
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

        <br></br>

        <div class="row">
          <button className="btn btn-success" onClick={this.enviarParaBackEnd}>
            Salvar
          </button>
        </div>
      </Layout>
    );
  }
}

function App() {
  return <ValidacaoClientes />;
}

const rootElement = document.getElementById("root");

ReactDOM.render(<App />, rootElement);
