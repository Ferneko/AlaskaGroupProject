import React from "react";
import ReactDOM from "react-dom";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

class ValidacaoEstoque extends React.Component {
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
    let enviarDados = {
      data: this.state.data,
      tipoMovimentacao: this.state.tipoMovimentacao,
      casquinhaId: this.state.casquinhaId,
      quantidadeCasquinha: Number(this.state.quantidadeCasquinha),
      adicionalId: this.state.adicionalid,
      quantidadeAdicional: Number(this.state.quantidadeAdicional),
      acompanhamentoId: this.state.acompanhamentoId,
      quantidadeAcompanhamento: Number(this.state.quantidadeAcompanhamento),
      saboresId: this.state.saboresid,
      quantidadeSabores: Number(this.state.quantidadeSabores),
    };
    console.log(enviarDados);
    Conexao.post("/Estoque", enviarDados)
      .then((resposta) => {
        // console.log('entrou aqui');
        const dados = resposta.data;
        console.log(dados.erro);
        if (dados.erro != null) {
          this.setState({ erro: dados.erro });
        } else {
          this.props.history.push("/Estoque"); //nao sei ainda oque fazer aqui
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

        <div className="row">
          <div className="form-group col-md-3">
            <label>Data</label>
            <input
              type="date"
              className="form-control"
              id="data"
              name="date"
              value={this.state.data}
              onChange={this.setData}
            />
          </div>

          <div className="form-group col-md-3">
            <label> Tipo de Movimentação </label>
            <select
              className="form-control"
              defaultValue={this.state.tipoMovimentacao}
              onChange={this.setTipoMovimentacao}
            >
              <option value="1">Entrada</option>
              <option value="0">Saída</option>
            </select>
          </div>
        </div>

        <div className="row">
          <div className="form-group col-md-3">
            <label>Casquinha</label>
            <select
              className="form-control"
              name="casquinhaid"
              value={this.state.casquinhaId}
              onChange={this.setCasquinhaid}
            >
              {this.state.todasCasquinhas.map((item) => (
                <option key={item.id} value={item.id}>
                  {item.nome}
                </option>
              ))}
            </select>
          </div>

          <div className="form-group col-md-3">
            <label>Qtd Casquinha</label>
            <input
              type="number"
              min="0"
              className="form-control"
              name="quantidadecasquinha"
              value={this.state.quantidadeCasquinha}
              onChange={this.setQuantidadeCasquinha}
            />
          </div>
        </div>

        <div className="row">
          <div className="form-group col-md-3">
            <label>Adicional</label>

            <select
              className="form-control"
              name="adicionalid"
              defaultValue={this.state.Adicionalid}
              onChange={this.setAdicionalid}
            >
              {this.state.todosAdicionais.map((item) => (
                <option key={item.id} value={item.id}>
                  {item.nome}
                </option>
              ))}
            </select>
          </div>

          <div className="form-group col-md-3">
            <label>Qtd Adicional</label>
            <input
              type="number"
              min="0"
              className="form-control"
              name="quantidadeAdicional"
              value={this.state.quantidadeAdicional}
              onChange={this.setQuantidadeAdicional}
            />
          </div>
        </div>

        <div className="row">
          <div className="form-group col-md-3">
            <label>Acompanhamento</label>

            <select
              className="form-control"
              name="acompanhamentoId"
              defaultValue={this.state.acompanhamentoId}
              onChange={this.setAcompanhamentoid}
            >
              {this.state.todosAcompanhamentos.map((item) => (
                <option key={item.id} value={item.id}>
                  {item.nome}
                </option>
              ))}
            </select>
          </div>

          <div className="form-group col-md-3">
            <label>Qtd Acompanhamento</label>
            <input
              type="number"
              min="0"
              className="form-control"
              name="quantidadeAcompanhamento"
              value={this.state.quantidadeAcompanhamento}
              onChange={this.setQuantidadeAcompanhamento}
            />
          </div>
        </div>

        <div className="row">
          <div className="form-group col-md-3">
            <label>Sabor</label>
            <select
              className="form-control"
              name="saborid"
              defaultValue={this.state.saboresid}
              onChange={this.setSaboresid}
            >
              {this.state.todosSabores.map((item) => (
                <option key={item.id} value={item.id}>
                  {item.name}
                </option>
              ))}
            </select>
          </div>

          <div className="form-group col-md-3">
            <label>Qtd Sabor</label>
            <input
              type="number"
              min="0"
              className="form-control"
              name="quantidadeSabor"
              value={this.state.quantidadeSabores}
              onChange={this.setQuantidadeSabores}
            />
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
  return <ValidacaoEstoque />;
}

const rootElement = document.getElementById("root");

ReactDOM.render(<App />, rootElement);
