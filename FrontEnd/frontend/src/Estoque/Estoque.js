import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";
import { Link } from "react-router-dom";

export default class Estoque extends Component {
  constructor(props) {
    super(props);
    this.state = {
      id: this.props.match.params.id,
      data: new Date().getDate(),
      tipoMovimentacao: 1, //entrada ==1 saida ==0
      casquinhaId: "",
      quantidadeCasquinha: 0,
      adicionalid: "",
      quantidadeAdicional: 0,
      acompanhamentoId: "",
      quantidadeAcompanhamento: 0,
      saboresid: "",
      quantidadeSabores: 0,
      erro: null,
      todasCasquinhas: [],
      todosAdicionais: [],
      todosAcompanhamentos: [],
      todosSabores: [],
    };

    this.setData = this.setData.bind(this);
    this.setTipoMovimentacao = this.setTipoMovimentacao.bind(this);
    this.setCasquinhaid = this.setCasquinhaid.bind(this);
    this.setQuantidadeCasquinha = this.setQuantidadeCasquinha.bind(this);
    this.setAdicionalid = this.setAdicionalid.bind(this);
    this.setQuantidadeAdicional = this.setQuantidadeAdicional.bind(this);
    this.setAcompanhamentoid = this.setAcompanhamentoid.bind(this);
    this.setQuantidadeAcompanhamento = this.setQuantidadeAcompanhamento.bind(this);
    this.setSaboresid = this.setSaboresid.bind(this);
    this.setQuantidadeSabores = this.setQuantidadeSabores.bind(this);
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
  }
  
  componentDidMount() {
    Conexao.get("/Estoque/NovaEntrada").then((resposta) => {
      const dados = resposta.data;
      if (dados.erro != null) {
        this.setState({ erro: dados.erro });
      } else {
        this.setState({
          todasCasquinhas: dados.todasCasquinhas,
          casquinhaId: dados.todasCasquinhas[0].id,

          todosAdicionais: dados.todosAdicionais,
          adicionalid: dados.todosAdicionais[0].id,

          todosAcompanhamentos: dados.todosAcompanhamentos,
          acompanhamentoId: dados.todosAcompanhamentos[0].id,

          todosSabores: dados.todosSabores,
          saboresid: dados.todosSabores[0].id,
        });
      }
    });
  }

  setData(e) {
    this.setState({
      data: e.target.value,
    });
  }

  setTipoMovimentacao(e) {
    let arrayValores = [
      this.state.quantidadeCasquinha,
      this.state.quantidadeAdicional,
      this.state.quantidadeAcompanhamento,
      this.state.quantidadeSabores,
    ];
    var i = 0;
    if (Number(e.target.value) === 1) {
      for (i = 0; i < arrayValores.length; i++) {
        if (arrayValores[i] < 0) {
          arrayValores[i] = arrayValores[i] * -1;
        }
      }
    } else {
      for (i = 0; i < arrayValores.length; i++) {
        if (arrayValores[i] > 0) {
          arrayValores[i] = arrayValores[i] * -1;
        }
      }
    }

    this.setState({
      tipoMovimentacao: Number(e.target.value),
      quantidadeCasquinha: arrayValores[0],
      quantidadeAdicional: arrayValores[1],
      quantidadeAcompanhamento: arrayValores[2],
      quantidadeSabores: arrayValores[3],
    });

    this.setState({
      tipoMovimentacao: e.target.value,
    });
  }

  setCasquinhaid(e) {
    this.setState({
      casquinhaId: e.target.value,
    });
  }
  setQuantidadeCasquinha(e) {
    this.setState({
      quantidadeCasquinha: e.target.value,
    });
  }
  setAdicionalid(e) {
    this.setState({
      adicionalid: e.target.value,
    });
  }
  setQuantidadeAdicional(e) {
    this.setState({
      quantidadeAdicional: e.target.value,
    });
  }
  setAcompanhamentoid(e) {
    this.setState({
      acompanhamentoId: e.target.value,
    });
  }
  setQuantidadeAcompanhamento(e) {
    this.setState({
      quantidadeAcompanhamento: e.target.value,
    });
  }
  setSaboresid(e) {
    this.setState({
      saboresid: e.target.value,
    });
  }
  setQuantidadeSabores(e) {
    this.setState({
      quantidadeSabores: e.target.value,
    });
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
        <div className="row" id="titulo-cadastro-movimentar-estoque">
          <h4>Movimentar Estoque</h4>
        </div>
        <br></br> <br></br>
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
        <div class="row">
              <div className="form-group col-md-12">
                <button className="btn btn-success" onClick={this.enviarParaBackEnd}> Salvar </button>
                <Link to={{pathname: "/ListaRelatorioEstoque"}} className="btn btn-danger" id="btn-danger-cadastro-estoque">Cancelar</Link>
              </div>
            </div>
      </Layout>
    );
  }
}
