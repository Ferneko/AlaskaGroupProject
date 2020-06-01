import React, { Component } from "react";
import Layout from "../Layout/Layout";
import Conexao from "../Conexao/Conexao";

export default class CadastroSabores extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: "",
      description: "",
      price: "",
      ativo: true,
    };
    this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);

    this.setName = this.setName.bind(this);
    this.setDescription = this.setDescription.bind(this);
    this.setPrice = this.setPrice.bind(this);
    this.setAtivo = this.setAtivo.bind(this);
  }

  setName(e) {
    this.setState({
      name: e.target.value,
    });
  }

  setDescription(e) {
    this.setState({
      description: e.target.value,
    });
  }

  setPrice(e) {
    this.setState({
      price: e.target.value,
    });
  }

  setAtivo(e) {
    this.setState({
      ativo: e.target.value === "true" ? true : false,
    });
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
