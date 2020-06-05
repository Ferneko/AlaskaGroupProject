import React from "react";
import ReactDOM from "react-dom";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

class ValidacaoCaixa extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      data: new Date(),
      tipoMovimentacao: 1,
      valor: "",
      descricao: "",
      erro: null,
    };

    this.handleChange.setData = this.setData.bind(this);
    this.handleChange.setTipoMovimentacao = this.setTipoMovimentacao.bind(this);
    this.handleChange.setValor = this.setValor.bind(this);
    this.handleChange.setDescricao = this.setDescricao.bind(this);
  }

  enviarParaBackEnd() {
    console.log(this.state);
    Conexao.post("/Caixa", {
      data: this.state.data,
      tipoMovimentacao: this.state.tipoMovimentacao,
      valor: Number(this.state.valor),
      descricao: this.state.descricao,
    })
      .then((resposta) => {
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          //alert("deu");
          this.props.history.push("/ListaCaixa");
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }

  handleChange(event) {
    this.setState({ data: event.target.data.replace(/[^\d\s-/]/g, "") });
    this.setState({ tipoMovimentacao: event.target.tipoMovimentacao.replace(/[^\d\s-/]/g, "") });
    this.setState({ valor: event.target.valor.replace(/[^\d\s-/]/g, "") });
    this.setState({ descricao: event.target.descricao.replace(/[^\d\s-/]/g, "") });
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
        <div className="col-4">
          <div className="form-group">
            <label>Data</label>
            <input
              type="date"
              className="form-control"
              id="nome"
              name="date"
              value={this.state.data}
              onChange={this.setData}
            />
          </div>
          <div className="form-group ">
            <label> Tipo de Movimentação: </label>
            <select
              className="form-control"
              defaultValue={this.state.tipoMovimentacao}
              onChange={this.setTipoMovimentacao}
            >
              <option value="1">Entrada</option>
              <option value="0">Saida</option>
            </select>
          </div>
          <div className="form-group">
            <label>Valor</label>
            <input
              type="number"
              className="form-control"
              name="valor"
              value={this.state.valor}
              onChange={this.setValor}
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
        </div>
        <br></br>

        <div className="row">
          <button className="btn btn-success" onClick={this.enviarParaBackEnd}>
            Salvar
          </button>
        </div>
        <div className="col-4"></div>
      </Layout>
    );
  }
}

function App() {
  return <ValidacaoCaixa />;
}

const rootElement = document.getElementById("root");

ReactDOM.render(<App />, rootElement);
