import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

export default class ControleCaixa extends Component {
  constructor(props) {
    super(props);

    this.state = {
      data: new Date(),
      tipoMovimentacao: 1,
      valor: "",
      descricao: "",
      erro: null,
    };

    this.setData = this.setData.bind(this);
    this.setTipoMovimentacao = this.setTipoMovimentacao.bind(this);
    this.setValor = this.setValor.bind(this);
    this.setDescricao = this.setDescricao.bind(this);
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
  }

  setData(e) {
    this.setState({
      data: e.target.value,
    });
  }

  setTipoMovimentacao(e) {
    let valor = this.state.valor;
    if (Number(e.target.value) === 1) {
      if (valor < 0) {
        valor = valor * -1;
      }
    } else {
      if (valor > 0) {
        valor = valor * -1;
      }
    }

    this.setState({
      tipoMovimentacao: Number(e.target.value),
      valor: valor,
    });
  }
  setValor(e) {
    let valorOk = e.target.value;
    if (this.state.tipoMovimentacao === 1) {
      if (valorOk < 0) {
        valorOk = valorOk * -1;
      }
    } else {
      if (valorOk > 0) {
        valorOk = valorOk * -1;
      }
    }
    this.setState({
      valor: valorOk,
    });
  }
  setDescricao(e) {
    this.setState({
      descricao: e.target.value,
    });
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

        <div className="row" id="titulo-controle-caixa">
            <h4>Controle de Caixa</h4>
        </div>

        <br></br>

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
