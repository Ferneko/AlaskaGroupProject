import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';

export default class CaixaInicial extends Component {
    constructor(props) {
        super(props)
        this.state = {

            data: new Date().getDate(),
            valor: "",
            erro: null
        }

        this.setData = this.setData.bind(this)
        this.setValor = this.setValor.bind(this)
 
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }


    setData(e) {
        this.setState({
            data: e.target.value,
        })

    }

    setValor(e) {
        this.setState({
            valor: e.target.value,
        })
    }


    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Caixa", {
            data: this.state.data,
            valor: Number(this.state.valor),
            

        }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {

                this.props.history.push('/CaixaInicial')
            }
        }).catch(error => {
            console.log(error)
        })


    }
    render() {
        return (
            <Layout>
                {this.state.erro != null ?
                    <div className="alert alert-danger alert-dismissible fade show" role="alert">
                        {this.state.erro}
                        <button type="button" onClick={() => this.setState({ erro: null })} className="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    : ""}

                <div className="row">
                        <div className="form-group" >
                            <label>Data</label>
                            <input type="date" className="form-control" id="data" name="date" value={this.state.data} onChange={this.setDate} />
                        </div>
                        

                        <div className="form-group">
                            <label>Valor</label>
                            <input type="number" className="form-control" name="valor" value={this.state.valor} onChange={this.setValor} />
                        </div>



                </div><br></br>

                <div className="row">
                    <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
                </div>

                <div className="col-4"></div>
                    

            
            </Layout>);
    }

}

