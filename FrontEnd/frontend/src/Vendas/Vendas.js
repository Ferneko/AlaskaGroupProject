import React, { Component } from 'react'
import Layout from '../Layout/Layout'
import Conexao from '../Conexao/Conexao'
export default class Vendas extends Component {
    constructor(props) {
        super(props)
        this.state = {
            listaSabores: [],
            listaCasquinhas: [],
            listaAcompanhamentos: [],
            listaAdicional: [],
           
            saborSelecionado: null,
            casquinhaSelecionada: null,
            acompanhamentosSelecionados: [],
            adicionaisSelecionados: [],
            valorPedido:0
        }
        this.selecionaSabor = this.selecionaSabor.bind(this);
        this.removeAdicionaisSelecionados = this.removeAdicionaisSelecionados.bind(this)
        this.removeAcompanhamentosSelecionados = this.removeAcompanhamentosSelecionados.bind(this)
        this.cancelar = this.cancelar.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }
    componentDidMount() {

        Conexao.get("/Vendas/Modelo").then((resposta) => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({
                    listaSabores: dados.listaSabores,
                    listaCasquinhas: dados.listaCasquinhas,
                    listaAcompanhamentos: dados.listaAcompanhamentos,
                    listaAdicional: dados.listaAdicionais

                });
            }
        });


    }

    
    cancelar(){
        this.setState({
             valorPedido: 0,
             saborSelecionado: null,
             casquinhaSelecionada: null,
             adicionaisSelecionados:[],
             acompanhamentosSelecionados:[]
        });
        window.location.reload(false);
    }

    selecionaSabor(id,e) {
        
       if(this.state.saborSelecionado != null){
           var valor = (this.state.valorPedido - this.state.saborSelecionado.price)+id.price;
          
           this.setState({ valorPedido: valor});
       }else{
            this.setState({ valorPedido:this.state.valorPedido + id.price})
       }

      
        this.setState({ saborSelecionado: id })
    }
    selecionaCasquinha(id, e) {
        if(this.state.casquinhaSelecionada != null ){
            var valor = (this.state.valorPedido - this.state.casquinhaSelecionada.preco) + id.preco;
            this.setState({ valorPedido:valor});
        }else{
            this.setState({ valorPedido:this.state.valorPedido + id.preco})
        }

        
        this.setState({ casquinhaSelecionada: id })
    }
    selecionaAdicional(id) {
        var novo = this.state.adicionaisSelecionados;
        novo.push(id);
        this.setState({ valorPedido:this.state.valorPedido + id.valor})
        this.setState({ adicionaisSelecionados: novo })
    }
    selecionaAcompanhamento(id) {
        var novo = this.state.acompanhamentosSelecionados;
        novo.push(id);
        this.setState({ valorPedido:this.state.valorPedido + id.valor})
        this.setState({ acompanhamentosSelecionados: novo })
    }

    removeAdicionaisSelecionados(i) {
        var novo = this.state.adicionaisSelecionados;
       
       this.setState({ valorPedido:this.state.valorPedido - novo[i].valor})
        novo.splice(i, 1);
      
        this.setState({ adicionaisSelecionados: novo })
    }

    removeAcompanhamentosSelecionados(i) {
        var novo = this.state.acompanhamentosSelecionados;
        this.setState({ valorPedido:this.state.valorPedido - novo[i].valor})
        novo.splice(i, 1);
        
        this.setState({ acompanhamentosSelecionados: novo })

        //const list = this.state.list;
        //list.splice(index, 1);
        //this.setState({ list });
    }

    enviarParaBackEnd() {
        
        Conexao.post("/Vendas", {
            saborSelecionado: this.state.saborSelecionado,
            casquinhaSelecionada: this.state.casquinhaSelecionada,
            adicionaisSelecionados:this.state.adicionaisSelecionados,
            acompanhamentosSelecionados:this.state.acompanhamentosSelecionados

        }).then(resposta => {
            const dados = resposta.data;
         
            if (dados.erro != null)
            {
                this.setState({ erro: dados.erro });
            } 
            else 
            {
                alert("Venda Efetuada com sucesso")
                window.location.reload(false);
                //this.props.history.push('/')
            }
        }).catch(error => {
            console.log(error)
        })


    }
    render() {
        return (
            <Layout>
                <h1>Nova Venda</h1>
                {this.state.erro != null ? (
                    <div className="alert alert-danger alert-dismissible fade show" role="alert" >
                        {this.state.erro}
                        <button type="button" onClick={() => this.setState({ erro: null })} className="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                ) : ("")}
                <div className="row">
                    <div className="col-3">
                        <div className="card">
                            <div className="card-header">
                                Escolha o Sabor
                            </div>
                            <ul className="list-group">
                                {this.state.listaSabores.map((item, i) =>
                                    <li key={i} className="list-group-item" >
                                        <input type="radio" name="Sabores" onClick={(event) => this.selecionaSabor(item, event)} className="form-check-input" value={item.id} />
                                        {item.name}<span style={{ float: "right" }}>R$ {item.price}</span>
                                    </li>)}
                            </ul>
                        </div>
                    </div>
                    <div className="col-3">
                        <div className="card">
                            <div className="card-header">
                                Escolha Casquinha
                            </div>
                            <ul className="list-group">
                                {this.state.listaCasquinhas.map((item, i) =>
                                    <li key={i} className="list-group-item" >
                                        <input type="radio" name="Casquinha" onClick={(event) => this.selecionaCasquinha(item, event)} className="form-check-input" value={item.id} />
                                        {item.nome}<span style={{ float: "right" }}>R$ {item.preco}</span>
                                    </li>)}
                            </ul>
                        </div>
                    </div>
                    <div className="col-3">
                        <div className="card">
                            <div className="card-header">
                                Escolha os adicionais
                            </div>
                            <ul className="list-group">
                                {this.state.listaAdicional.map((item, i) =>
                                    <li key={i} className="list-group-item">
                                        {item.nome}
                                        <button style={{ float: "right" }} className="btn btn-sm btn-success" onClick={(event) => this.selecionaAdicional(item, event)}>+</button>
                                        <span style={{ float: "right" }}> | R$ {item.valor}<span style={{ color: "white" }}> . </span></span>
                                    </li>)}
                            </ul>
                        </div>
                    </div>
                    <div className="col-3">
                        <div className="card">
                            <div className="card-header">
                                Escolha os acompanhamentos
                            </div>
                            <ul className="list-group">
                                {this.state.listaAcompanhamentos.map((item, i) =>
                                    <li key={i} className="list-group-item">
                                        {item.nome}
                                        <button style={{ float: "right" }} onClick={(event) => this.selecionaAcompanhamento(item, event)} className="btn btn-sm btn-success">+</button>
                                        <span style={{ float: "right" }}> | R$ {item.valor}  <span style={{ color: "white" }}> . </span></span>
                                    </li>)}
                            </ul>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-5">
                        <div className="card"  >
                            <div className="card-header">
                                Seu Pedido
                            </div>
                            <ul className="list-group" style={{ "maxHeight": " 150px" }}>
                                {this.state.casquinhaSelecionada != null ? <div className="list-group-item"> {this.state.casquinhaSelecionada.nome}<span style={{ float: "right" }}>R$ {this.state.casquinhaSelecionada.preco}</span></div> : ""}
                                {this.state.saborSelecionado != null ? <div className="list-group-item">{this.state.saborSelecionado.name}<span style={{ float: "right" }}>R$ {this.state.saborSelecionado.price}</span></div> : ""}


                                {this.state.adicionaisSelecionados.map((item, i) =>
                                    <li key={i} className='list-group-item'>
                                        {item.nome} <button style={{ float: "right" }} className="btn btn-sm btn-danger" onClick={(event) => this.removeAdicionaisSelecionados(i)}>Remover</button>
                                        <span style={{ float: "right", }}> | R$ {item.valor}<span style={{ color: "white" }}> . </span></span>
                                    </li>)
                                }

                                {this.state.acompanhamentosSelecionados.map((item, i) =>
                                    <li key={i} className='list-group-item'>
                                        {item.nome} <button style={{ float: "right" }} className="btn btn-sm btn-danger" onClick={(event) => this.removeAcompanhamentosSelecionados(i)}>Remover</button>
                                        <span style={{ float: "right" }}> | R$ {item.valor}<span style={{ color: "white" }}> . </span></span>
                                    </li>)
                                }
                            </ul>
                        </div>
                    </div>
                    <div className="col-5">
                        <table>
                            <tbody>
                                
                                <tr>
                                    <td><div className="list-group-item"><h2>Valor Total</h2></div></td>
                                    <td><div className="list-group-item"><h2>R$ {this.state.valorPedido}</h2></div></td>
                                </tr>
                                <tr>
                                    <td><div className="list-group-item"><button className="btn btn-success" onClick={this.enviarParaBackEnd}>Finalizar Venda</button></div></td>
                                    <td><div className="list-group-item"><button className="btn btn-danger" onClick={this.cancelar}>Cancelar Venda</button></div></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </Layout >
        )
    }
}