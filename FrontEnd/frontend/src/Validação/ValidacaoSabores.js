import React from "react";
import ReactDOM from "react-dom";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

class ValidacaoSabores extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      name: "",
      description: "",
      price: "",
      ativo: true,
      erro: null,
    };

    this.handleChange.setNome = this.setNome.bind(this);
    this.handleChange.setTipo = this.setTipo.bind(this);
    this.handleChange.setValor = this.setValor.bind(this);
    this.handleChange.setAtivo = this.setAtivo.bind(this);
  }

  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Sabores", {
      Name: this.state.name,
      Description: this.state.description,
      Price: Number(this.state.price),
      Ativo: this.state.ativo,
    })
      .then((resposta) => {
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          //alert("deu");
          this.props.history.push("/ListaSabores");
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }

  handleChange(event) {
    this.setState({ name: event.target.name.replace(/[^\d\s-/]/g, "") });
    this.setState({ description: event.target.description.replace(/[^\d\s-/]/g, "") });
    this.setState({ price: event.target.price.replace(/[^\d\s-/]/g, "") });
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
                name="name"
                value={this.state.name}
                onChange={this.setName}
              />
            </div>
            <div className="form-group">
              <label>Descrição</label>
              <input
                type="text"
                className="form-control"
                name="description"
                value={this.state.description}
                onChange={this.setDescription}
              />
            </div>
            <div className="form-group">
              <label>Preço</label>
              <input
                type="number"
                className="form-control"
                name="price"
                value={this.state.price}
                onChange={this.setPrice}
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
  return <ValidacaoSabores />;
}

const rootElement = document.getElementById("root");

ReactDOM.render(<App />, rootElement);
