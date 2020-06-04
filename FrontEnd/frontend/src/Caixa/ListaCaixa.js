import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import {Link} from 'react-router-dom';
import Conexao from '../Conexao/Conexao';

export default class ListaCaixa extends Component {
    constructor(props) {
        super(props)
        this.state = {
            ListaCaixa: [],
            query : "",
            erro : null
        }
        this.pesquisar = this.pesquisar.bind(this);
        this.delete = this.delete.bind(this);
        this.atualizaQuery = this.atualizaQuery.bind(this);
    }
    atualizaQuery(e){
        this.setState({ query : e.target.value });
    }
    componentDidMount() {
        Conexao.get("/Caixa").then(resposta => {
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ ListaCaixa : dados });
            }
        });
    }

    pesquisar(e){
        console.log(this.state.query)
        var data = this.state.query
        Conexao.get("/Caixa/PesquisarCaixa/"+data).then(resposta => {
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ ListaCaixa : dados });
            } 
            
        });
    }

    delete(e){
        
        Conexao.delete("/Caixa", {params: { id: e.target.dataset.objeto }}).then(resposta => {
            console.log(resposta.data)
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ ListaCaixa : dados });
            }
        });

        Conexao.get("/Caixa").then(resposta => {
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ listaCaixa : dados });
            }
        });
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
                    <div className="col-12">
                        <div className="card">
                            <div className="card-header">
                                Pesquisar
                            </div>
                            <div className="card-body">
                                <div className="row">
                                    <div className="col-2">
                                        <Link to="/ControleCaixa" className="btn btn-success">Controle de caixa</Link>
                                    </div>
                                    <div className="col-10">
                                        <div className="input-group">
                                            <input type="date" className="form-control" placeholder="Digite aqui sua pesquisa" onChange={this.atualizaQuery} aria-label="Digite aqui sua pesquisa" aria-describedby="basic-addon2" />
                                            <div className="input-group-append">
                                                <button className="btn btn-primary" type="button" onClick={this.pesquisar}>Pesquisar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <br />
                <div className="row">
                    <div className="col-12">
                        <div className="card">
                            <div className="card-body">
                                <table className="table table-houver">
                                    <thead>
                                        <tr>
                                            <th>id</th>
                                            <th>data</th>
                                            <th>movimentação</th>
                                            <th>preço</th>
                                            <th>descrição</th>
                                           
                                            <th></th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                    
                                    
                                        {this.state.ListaCaixa.map((item) =>
                                            <tr key={item.id}>
                                                <td>{item.id}</td>
                                                <td>{item.data}</td>
                                                <td>{item.tipoMovimentacao === 1 ? "Entrada" : "Saída"}</td>
                                                <td>{item.valor}</td>
                                                <td>{item.descricao}</td>
                                              
                                              
                                                <td><button className="btn btn-danger" onClick={this.delete} data-objeto={item.id}>Excluir</button></td>


                                            </tr>
                                        )}
                                    </tbody>
                                </table>

                            </div>
                        </div>
                    </div>

                </div>
            </Layout>);
    }
}