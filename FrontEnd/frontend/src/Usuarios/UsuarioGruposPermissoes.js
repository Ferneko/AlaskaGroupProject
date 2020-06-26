import React, { Component } from "react";
import Layout from "../Layout/Layout";

import Conexao from "../Conexao/Conexao";

export default class UsuarioPermissoes extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idGrupoUsuario: this.props.match.params.id,
            ListaUsuariosGrupoUsuarios: [],
            erro: null,
            query: "",
        };
        this.pesquisar = this.pesquisar.bind(this);
        this.delete = this.delete.bind(this);
        this.atualizaQuery = this.atualizaQuery.bind(this);
        this.salvar = this.salvar.bind(this);
        this.getAll = this.getAll.bind(this);
    }

    atualizaQuery(e) {
        this.setState({ query: e.target.value });
    }

    componentDidMount() {
       this.getAll()
    }

    getAll(){
        Conexao.get("/UsuariosGrupoUsuarios/" + this.state.idGrupoUsuario).then((resposta) => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({ ListaUsuariosGrupoUsuarios: dados });
            }
        });
    }

    pesquisar(e) {
        console.log(this.state.query);
        var data = this.state.query;
        Conexao.get("/UsuariosGrupoUsuarios/PesquisarUsuariosGrupoUsuarios/" + this.state.idGrupoUsuario + "/" + data).then(
            (resposta) => {
                const dados = resposta.data;
                if (dados.erro != null) {
                    this.setState({ erro: dados.erro });
                } else {
                    this.setState({ ListaUsuariosGrupoUsuarios: dados });
                }
            }
        );
    }

    delete(idGrupoUsuario, idUsuario,item) {
        //Conexao.delete("/GrupoUsuarioPermissao", { params: { id: e.target.dataset.objeto },
        Conexao.delete("/UsuariosGrupoUsuarios/" + idGrupoUsuario + "/" + idUsuario
        ).then((resposta) => {
            console.log(resposta.data);
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.getAll()
                
            }
        });
       


    }

    salvar(idGrupoUsuario, idUsuario, item) {
        console.log("Salvar "+idGrupoUsuario + "," + idUsuario+"")
        Conexao.post("/UsuariosGrupoUsuarios", {
            idGrupoUsuario: Number(idGrupoUsuario),
            idUsuario: Number(idUsuario)
        })
            .then((resposta) => {
                const dados = resposta.data;
                console.log(resposta + " dados erro");
                if (dados.erro != null) {
                    console.log(" if do erro");
                    this.setState({ erro: dados.erro });
                }
                else {
                    this.getAll()
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
                    <div className="alert alert-danger alert-dismissible fade show" role="alert">
                        {this.state.erro}
                        <button type="button" onClick={() => this.setState({ erro: null })} className="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                ) : (
                        ""
                    )}

                <div className="row">
                    <div className="col-12">
                        <div className="card">
                            <div className="card-header">Pesquisar</div>
                            <div className="card-body">
                                <div className="row">

                                    <div className="col-12">
                                        <div className="input-group">
                                            <input type="text" className="form-control" placeholder="Digite aqui sua pesquisa" onChange={this.atualizaQuery} aria-label="Digite aqui sua pesquisa" aria-describedby="basic-addon2" />
                                            <div className="input-group-append">
                                                <button
                                                    className="btn btn-primary"
                                                    type="button"
                                                    onClick={this.pesquisar}
                                                >
                                                    Pesquisar
                                                 </button>
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
                                            <th></th>
                                           
                                            <th>Nome</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {this.state.ListaUsuariosGrupoUsuarios.map((item, i) => (
                                            <tr key={i}>
                                                <td> 
                                                    {item.ativo}
                                                    {item.ativo === true ?
                                                        <button className="btn btn-danger" onClick={() => this.delete(item.idGrupoUsuario, item.idUsuario)}>Remover Grupo</button>
                                                        :
                                                        <button className="btn btn-success" onClick={() => this.salvar(item.idGrupoUsuario, item.idUsuario)}>Adicionar Grupo</button>
                                                    }
                                                </td>
                                               
                                                <td>{item.nome}</td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </Layout>
        );
    }
}
