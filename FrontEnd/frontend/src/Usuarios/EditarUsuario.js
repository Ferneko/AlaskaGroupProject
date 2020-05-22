import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';

export default class EditarUsuario extends Component {
    constructor(props) {
        super(props)

        //console.log(props);
        //console.log(this.props.match.params.id);
        this.state = {
            id: this.props.match.params.id,
            nome: "",
            login: "",
            senha: "",
            ativo: true,
            erro: null
        }

        this.setNome = this.setNome.bind(this)
        this.setLogin = this.setLogin.bind(this)
        this.setSenha = this.setSenha.bind(this)
        this.setAtivo = this.setAtivo.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }

    componentDidMount() {
        Conexao.get("/Usuarios/" + this.state.id).then(resposta => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({

                    id: dados.id,
                    nome: dados.nome,
                    login: dados.login,
                    senha: dados.senha,
                    ativo: dados.ativo

                });
            }
        });
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
            ativo: e.target.value === 'true' ? true : false
        });
    }
    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Usuarios", {
            id: this.state.id,
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
                //alert("deu");
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

                <div className="col-4"></div>
                <div className="col-4">

                    <div className="form-group">
                        <label>Código</label>
                        <input type="text" readOnly={true} className="form-control" id="id" name="id" value={this.state.id} />
                    </div>
                    <div className="form-group"  >
                        <label>Nome</label>
                        <input type="text" className="form-control" id="nome" name="nome" value={this.state.nome} onChange={this.setNome} />
                    </div>
                    <div className="form-group" >
                        <label>Login</label>
                        <input type="text" className="form-control" id="cpf" name="login" value={this.state.login} onChange={this.setLogin} />
                    </div>
                    <div className="form-group" >
                        <label>Senha</label>
                        <input type="password" className="form-control" name="senha" value={this.state.senha} onChange={this.setSenha} />
                    </div>
                    
                        <div className="form-group ">
                            <label> Ativo: </label>
                            <select className="form-control" value={this.state.ativo} onChange={this.setAtivo}>
                                <option value="true">Sim</option>
                                <option value="false">Não</option>
                            </select>
                        </div>

                    </div>
                    <br></br>




                    <div className="row">
                        <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
                    </div>

            </Layout>);
    }
}   