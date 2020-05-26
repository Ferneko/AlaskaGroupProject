import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';
 
export default class EntradaCaixa extends Component {
    constructor(props) {
        super(props)
        this.state = {
           
            id: "",
            data: "",
            tipo: Boolean,
            price: "",
            description: "",
            ativo: true,

        }
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this)
    
        this.setData = this.setData.bind(this)
        this.setTipo = this.setTipo.bind(this)
        this.setPrice = this.setPrice.bind(this)
        this.setDescription = this.setDescription.bind(this)
    }

  
    setData(e) {
        this.setState({
            data: e.target.value,
        })
    }

    setTipo(e) {
        this.setState({
            tipo: e.target.value,
        })
    }

    setPrice(e) {
        this.setState({
            price: e.target.value,
        })
    }

    setDescription(e) {
        this.setState({
            description: e.target.value,
        })
    }

    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/EntradaCaixa", { 
            data: this.state.data,
            tipo: this.state.tipo,
            price:  Number(this.state.price),
            Description: this.state.description,
         

         }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                //alert("deu");
                this.props.history.push('/EntradaCaixa')
            }
        }).catch(error => {
           console.log(error)
        })


    }
 
    


    render() {
        return (<Layout><div className="row">
            <div className="col-4"></div>
            <div className="col-4">
              
                <div className="form-group">
                    <label>Data</label>
                    <input type="date" className="form-control" name="data" value={this.state.data} onChange={this.setData} />
                </div>
                <div className="form-group">
                    <label>Tipo de Movimentação</label>
                    <select className="form-control" value={this.state.tipo} onChange={this.setTipo}>
                                <option value="true">Entrada</option>
                                <option value="false">Saida</option>
                            </select>
                </div>
                <div className="form-group">
                    <label>Valor</label>
                    <input type="number" className="form-control" name="price" value={this.state.price} onChange={this.setPrice} />
                </div>
                <div className="form-group">
                    <label>Descrição</label>
                    <input type="text" className="form-control" name="description" value={this.state.valor} onChange={this.setDescription} />
                </div>
                <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
            </div>
            <div className="col-4"></div>

        </div></Layout>);
    }  
   
};