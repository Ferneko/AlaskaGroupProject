import React, { Component } from 'react';
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';

export default class CadastroAcompanhamentos  extends Component {

    constructor(props) {
        super(props)
        this.state = {
            imagem: "",
            id: "",
            nome: "",
            descricao: "",
            valor: "",
            ativo: true,
            erro: null
        }
        
        this.setImagem = this.setImagem.bind(this)
        this.setId = this.setId.bind(this)
        this.setNome = this.setNome.bind(this)
        this.setDescricao = this.setDescricao.bind(this)
        this.setValor = this.setValor.bind(this)
        this.setAtivo = this.setAtivo.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }

    setImagem(e) {
        this.setState({
            imagem: e.target.value,
        })
    }
    setId(e) {
        this.setState({
            id: e.target.value,
        })
    }
    setNome(e) {
        this.setState({
            nome: e.target.value,
        })
    }
    setDescricao(e) {
        this.setState({
            descricao: e.target.value,
        })
    }
    setValor(e) {
        this.setState({
            valor: e.target.value,
        })
    }
    setAtivo(e) {
        this.setState({
            ativo: e.target.value,
        })
    }

    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Acompanhamentos", { 
            imagem: this.state.imagem,
            nome: this.state.nome,
            descricao: this.state.descricao,
            valor: this.state.valor,
            ativo: this.state.ativo
         }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                alert("deu");
                this.props.history.push('/ListaAcompanhamentos')
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
                            <label>Imagem</label>
                            <input type="text" className="form-control" id="imagem" name="imagem" value={this.state.imagem} onChange={this.setImagem} />
                        </div>

                        <div className="form-group">
                            <label>Id</label>
                            <input type="text" className="form-control" id="id" name="id" value={this.state.id} onChange={this.setId} />
                        </div>

                        <div className="form-group">
                            <label>Nome</label>
                            <input type="text" className="form-control" id="nome" name="nome" value={this.state.nome} onChange={this.setNome} />
                        </div>

                        <div className="form-group">
                            <label>Descricao</label>
                            <input type="text" className="form-control" id="descricao" name="descricao" value={this.state.descricao} onChange={this.setDescricao} />
                        </div>

                        <div className="form-group">
                            <label>Valor</label>
                            <input type="text" className="form-control" id="valor" name="valor" value={this.state.valor} onChange={this.setValor} />
                        </div>

                        <div className="form-group ">
                            <label> Ativo: </label>
                            <select className="form-control" value={this.state.ativo} onChange={this.setAtivo}>
                             <option value="">Selecione...</option>
                             <option value="1">Sim</option>
                             <option value="2">Não</option>
                            </select>
                        </div>

                        <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
                    </div>
                    <div className="col-4"></div>
                </div>
            </Layout>);
    }

}