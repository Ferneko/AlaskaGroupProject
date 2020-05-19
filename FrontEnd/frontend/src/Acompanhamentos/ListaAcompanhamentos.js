import React, { Component } from 'react';
import Layout from '../Layout/Layout';
import {Link} from 'react-router-dom';
import Conexao from '../Conexao/Conexao';

export default class ListaAcompanhamentos extends Component {
    
    constructor(props) {
        super(props)
        this.state = {
            ListaAcompanhamentos: [],
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
        Conexao.get("/Acompanhamentos").then(resposta => {
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ ListaAcompanhamentos : dados });
            }
        });
    }

    pesquisar(e){
        console.log(this.state.query)
        var data = this.state.query
        Conexao.get("/Acompanhamentos/PesquisarAcompanhamentos/"+data).then(resposta => {
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ ListaAcompanhamentos : dados });
            }
        });
    }

    delete(e){
        Conexao.delete("/Acompanhamentos", {params: { id: e.target.dataset.objeto }}).then(resposta => {
            console.log(resposta.data)
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ ListaAcompanhamentos : dados });
            }
        });
        Conexao.get("/Acompanhamentos").then(resposta => {
            const dados = resposta.data;
            if(dados.erro != null){
                this.setState({ erro : dados.erro });
            }else{
                this.setState({ ListaAcompanhamentos : dados });
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
                                        <Link to="/CadastroAcompanhamento" className="btn btn-success">Novo Acompanhamento</Link>
                                    </div>
                                    <div className="col-10">
                                        <div className="input-group">
                                            <input type="text" className="form-control" placeholder="Digite aqui sua pesquisa" onChange={this.atualizaQuery} aria-label="Digite aqui sua pesquisa" aria-describedby="basic-addon2" />
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
                                            <th>Id</th>
                                            <th>Imagem</th>
                                            <th>Nome</th>
                                            <th>Descrição</th>
                                            <th>Valor</th>
                                            <th>Ativo</th>
                                        </tr>
                                    </thead>
                                <tbody>
                                    {this.state.ListaAcompanhamentos.map((item) =>
                                        <tr key={item.id}>
                                            <td>{item.imagem}</td>
                                            <td>{item.nome}</td>
                                            <td>{item.descricao}</td>
                                            <td>{item.valor}</td>
                                            <td>{item.ativo}</td>
                                            <td><button className="btn btn-warning">Editar</button></td>
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