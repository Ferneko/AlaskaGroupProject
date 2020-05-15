import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';
import { browserHistory } from 'react-router'
export default class CadastroUsuario extends Component {
    constructor(props) {
        super(props)
        this.state = {

            nome: "",
            login: "",
            senha: "",
            ativo: true,
            erro: null
        }

        this.setNome = this.setNome.bind(this)
        this.setLogin = this.setCpf.bind(this)
        this.setSenha = this.setTelefone.bind(this)
        this.setAtivo = this.setAtivo.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }


    setNome(e) {

        this.setState({
            nome: e.target.value,
        })
    }
    setLogin(e) {
        this.setState({
            login: e.target.value,
        })
    }
    setSenha(e) {
        this.setState({
            senha: e.target.value,
        })
    }
    setAtivo(e) {
        this.setState({
            ativo: e.target.value,
        })
    }
    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Usuario", { 
            nome: this.state.nome,
            login: this.state.login,
            senha: this.state.senha,
            ativo: this.state.ativo

         }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                alert("deu");
                this.props.history.push('/ListaUsuarios')
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
                        <div className="form-group">
                            <label>Nome</label>
                            <input type="text" className="form-control" id="nome" name="nome" value={this.state.nome} onChange={this.setNome} />
                        </div>
                        <div className="form-group">
                            <label>Login</label>
                            <input type="text" className="form-control" id="login" name="login" value={this.state.login} onChange={this.setlogin} />
                        </div>
                        <div className="form-group">
                            <label>Senha</label>
                            <input type="text" className="form-control" name="senha" value={this.state.senha} onChange={this.setsenha} />
                        </div>
                        <div className="form-group">
                            <label>Ativo</label>
                            <input type="checkbox" className="form-control" name="ativo" value={this.state.ativo} onChange={this.setAtivo} />
                        </div>
                        <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
                    </div>
                    <div className="col-4"></div>

                </div>
            </Layout>);
    }
}

