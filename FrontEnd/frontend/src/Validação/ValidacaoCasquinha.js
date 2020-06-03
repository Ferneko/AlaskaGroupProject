import React from "react";
import ReactDOM from "react-dom";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

class ValidacaoCasquinha extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      nome: "",
      tipo: "",
      preco: "",
      ativo: true,
    };

    this.handleChange.setNome = this.setNome.bind(this);
    this.handleChange.setTipo = this.setTipo.bind(this);
    this.handleChange.setPreco = this.setPreco.bind(this);
    this.handleChange.setAtivo = this.setAtivo.bind(this);
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

  handleChange(event) {
    this.setState({ nome: event.target.nome.replace(/[^\d\s-/]/g, "") });
    this.setState({ tipo: event.target.tipo.replace(/[^\d\s-/]/g, "") });
    this.setState({ preco: event.target.preco.replace(/[^\d\s-/]/g, "") });
    this.setState({ ativo: event.target.ativo.replace(/[^\d\s-/]/g, "") });
  }

  render() {
    return (
      <Layout>
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
                onChange={this.handleChange.setNome}
              />
            </div>

            <div className="form-group">
              <label>Tipo</label>
              <input
                type="text"
                className="form-control"
                id="tipo"
                name="tipo"
                value={this.state.tipo}
                onChange={this.handleChange.setTipo}
              />
            </div>

            <div className="form-group">
              <label>Preço</label>
              <input
                type="number"
                className="form-control"
                name="preco"
                value={this.state.preco}
                onChange={this.handleChange.setPreco}
              />
            </div>

            <div className="form-group ">
              <label> Ativo: </label>
              <select
                className="form-control"
                value={this.state.ativo}
                onChange={this.handleChange.setAtivo}
              >
                <option value="true">Sim</option>
                <option value="false">Não</option>
              </select>
            </div>
          </div>
        </div>
        <br></br>
        <div className="row">
          <button className="btn btn-success" onClick={this.enviarParaBackEnd}>
            Salvar
          </button>
        </div>
      </Layout>
    );
  }
}

function App() {
  return <ValidacaoCasquinha />;
}

const rootElement = document.getElementById("root");

ReactDOM.render(<App />, rootElement);
