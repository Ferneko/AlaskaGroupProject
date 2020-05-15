import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';
 
export default class CadastroSabores extends Component {
    constructor(props) {
        super(props)
        this.state = {
            id: "",
            name: "",
            description: "",
            price: "",
            ativo: true,

        }
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this)
        this.setId = this.setId.bind(this)
        this.setName = this.setName.bind(this)
        this.setDescription = this.setDescription.bind(this)
        this.setPrice = this.setPrice.bind(this)
    }

    setId(e) {
        this.setState({
            id: e.target.value,
        })
    }

    setName(e) {
        this.setState({
            name: e.target.value,
        })
    }

    setDescription(e) {
        this.setState({
            description: e.target.value,
        })
    }

    setPrice(e) {
        this.setState({
            price: e.target.value,
        })
    }
    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Sabores", { 
            name: this.state.name,
            description: this.state.description,
            price: this.state.price,
            ativo: this.state.ativo

         }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                alert("deu");
                this.props.history.push('/ListaSabores')
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
                    <label>Id</label>
                    <input type="text" className="form-control" name="id" value={this.state.id} onChange={this.setId} />
                </div>
                <div className="form-group">
                    <label>Name</label>
                    <input type="text" className="form-control" name="name" value={this.state.name} onChange={this.setName} />
                </div>
                <div className="form-group">
                    <label>description</label>
                    <input type="text" className="form-control" name="description" value={this.state.description} onChange={this.setDescription} />
                </div>
                <div className="form-group">
                    <label>Price</label>
                    <input type="text" className="form-control" name="price" value={this.state.price} onChange={this.setPrice} />
                </div>
                <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
            </div>
            <div className="col-4"></div>

        </div></Layout>);
    }  
   
};