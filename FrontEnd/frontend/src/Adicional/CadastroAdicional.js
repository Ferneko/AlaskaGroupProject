import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';
import { browserHistory } from 'react-router'
export default class CadastroAdicional extends Component {
    constructor(props) {
        super(props)
        this.state = {

            nome: "",
            tipo: "",
            valor: "",
            ativo: true,
            erro: null
        }

        this.setNome = this.setNome.bind(this)
        this.setTipo = this.setTipo.bind(this)
        this.setValor = this.setValor.bind(this)
        this.setAtivo = this.setAtivo.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }


    setNome(e) {
        this.setState({
            nome: e.target.value,
        })

    }

    setTipo(e) {
        this.setState({
            tipo: e.target.value,
        })
    }

    setValor(e) {
        this.setState({
            preco: e.target.value,
        })
    }
  
    setAtivo(e) {
        let valor = e.target.value == 1 ? true: false;
        this.setState({
            ativo: valor,
        })
    }
    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Adicional", { 
            nome: this.state.nome,
            tipo: this.state.tipo,
            valor: this.state.preco,
            ativo: this.state.ativo,

         }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
               
                this.props.history.push('/ListaAdicional')
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

                    <div className="col-4"></div>
                    <div className="col-4">
                    
                        
                        <div className="form-group" >
                            <label>Nome</label>
                            <input type="text" className="form-control" id="nome" name="nome" value={this.state.nome} onChange={this.setNome} />
                        </div>
                       
                        
                        <div className="form-group" >
                            <label>Tipo</label>
                            <input type="text" className="form-control" id="tipo" name="tipo" value={this.state.tipo} onChange={this.setTipo} />
                        </div>
                        
                        <div className="form-group" >
                            <label>Valor</label>
                            <input type="text" className="form-control" name="valor" value={this.state.valor} onChange={this.setValor} />
                       </div>

                       <div className="form-group ">
                        <label> Ativo: </label>
                            <select className="form-control" onChange={this.setAtivo}>
                             <option value="1">Sim</option>
                             <option value="0">Não</option>
                            </select>
                        </div>
                        </div>
                        
                        
                        
                    </div><br></br>
                   
                    <div className="row">
                        <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
                     </div>
                     
                    <div className="col-4"></div>

               
            </Layout>);
    }
}

