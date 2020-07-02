import React, { Component } from "react";
import "../Login/login.css"
import Conexao from "../Conexao/Conexao";


export default class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            login: "",
            senha: "",
            erro:""
        };
        this.setLogin = this.setLogin.bind(this);
        this.setSenha = this.setSenha.bind(this);
        this.enviarDados = this.enviarDados.bind(this);
    }

   

    setLogin(e){
        this.setState({
            login:e.target.value
        });
       
    }
    setSenha(e){
        this.setState({
            senha:e.target.value
        });
       
    }

    enviarDados(){
        Conexao.post("/Login", { login:this.state.login, senha:this.state.senha })
            .then((resposta) => {

              const dados = resposta.data;
            
              if (dados.erro != null) {
                this.setState({ erro: dados.erro });
              } else {

                localStorage.setItem('tokenJWT',resposta.data.token);
               console.log(resposta.data.roles)
                for (var i = 0; i < resposta.data.roles.length; i ++) {
                   
                    localStorage.setItem(resposta.data.roles[i],resposta.data.roles[i]); 
                }
                this.props.history.push("/");
              }
            })
            .catch((error) => {
               //this.setState({ erro: dados.erro });
            });
    }

    render() {
        return (
            <div id="logreg-forms">
                <div className="form-signin formClass">
                    <h1 className="h3 mb-3 font-weight-normal" style={{textAlign:"center"}}>Iniciar Sessão</h1>
                    <input type="email" id="inputEmail" name="login" className="form-control" placeholder="Login"  onChange={this.setLogin} />
                    <input type="password" id="inputPassword" name="senha" className="form-control" placeholder="Senha"  onChange={this.setSenha} />
                    <button className="btn btn-success btn-block" onClick={this.enviarDados}><i className="fas fa-sign-in-alt"></i> Iniciar Sessão </button>
                    <hr />
                </div>
            </div>
        )
    }
}