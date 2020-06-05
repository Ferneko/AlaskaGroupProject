import React from "react";
import ReactDOM from "react-dom";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

class ValidacaoUsuarios extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      nome: "",
      login: "",
      senha: "",
      ativo: true,
      erro: null,
    };

    this.handleChange.setNome = this.setNome.bind(this);
    this.handleChange.setLogin = this.setLogin.bind(this);
    this.handleChange.setSenha = this.setSenha.bind(this);
    this.handleChange.setAtivo = this.setAtivo.bind(this);
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

  handleChange(event) {
    this.setState({ nome:  event.target.nome.replace(/[^\d\s-/]/g, "") });
    this.setState({ login: event.target.login.replace(/[^\d\s-/]/g, "") });
    this.setState({ senha: event.target.senha.replace(/[^\d\s-/]/g, "") });
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

        <div className="row">
          <div className="col-4"></div>
          <div className="col-4">
            <div className="form-group">
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
            <div className="form-group">
              <label>Login</label>
              <input
                type="text"
                className="form-control"
                id="login"
                name="login"
                value={this.state.login}
                onChange={this.setLogin}
              />
            </div>
            <div className="form-group">
              <label>Senha</label>
              <input
                type="password"
                className="form-control"
                name="senha"
                value={this.state.senha}
                onChange={this.setSenha}
              />
            </div>

            <div className="form-group ">
              <label> Ativo: </label>
              <select
                value={this.state.ativo}
                className="form-control"
                onChange={this.setAtivo}
              >
                <option value="true">Sim</option>
                <option value="false">Não</option>
              </select>
            </div>
            <button
              className="btn btn-success"
              onClick={this.enviarParaBackEnd}
            >
              Salvar
            </button>
          </div>
          <div className="col-4"></div>
        </div>
      </Layout>
    );
  }
}

function App() {
  return <ValidacaoUsuarios />;
}

const rootElement = document.getElementById("root");

ReactDOM.render(<App />, rootElement);
