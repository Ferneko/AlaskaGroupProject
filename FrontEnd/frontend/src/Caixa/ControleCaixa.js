import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';

export default class ControleCaixa extends Component {
    constructor(props) {
        super(props)

        //console.log(props);
        //console.log(this.props.match.params.id);
        this.state = {
            id: this.props.match.params.id,
            data: "",
            tipoMovimentacao: "",
            valor: "",
            descricao: "",
            erro: null
        }
        
        this.setData = this.setData.bind(this)
        this.setTipoMovimentacao = this.setTipoMovimentacao.bind(this)
        this.setValor = this.setValor.bind(this)
        this.setDescricao = this.setDescricao.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }

    componentDidMount() {
        Conexao.get("/Caixa/" + this.state.id).then(resposta => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({

                    id: dados.id,
                    data: dados.data,
                    tipoMovimentacao: dados.tipoMovimentacao,
                    valor: dados.valor,
                    descricao: dados.descricao

                });
            }
        });
    }

    setData(e) {
        this.setState({
            data: e.target.value,
        })
    }

    setTipoMovimentacao(e) {
        this.setState({
            tipoMovimentacao: e.target.value === 'true' ? true : false
        });
    }
    setValor(e) {
        this.setState({
            valor: e.target.value,
        })
    }
    setDescricao(e) {
        this.setState({
            descricao: e.target.value,
        })
    }
    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Caixa", {
            id: this.state.id,
            data: this.state.data,
            tipoMovimentacao: this.state.tipo,
            valor: this.state.valor,
            descricao: this.state.descricao
            

        }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                //alert("deu");
                this.props.history.push('/Caixa')
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
                        <label>Data</label>
                        <input type="date" className="form-control" id="nome" name="date" value={this.state.data} onChange={this.setData} />
                    </div>
                    <div className="form-group ">
                        <label> Tipo de Movimentação: </label>
                        <select className="form-control" value={this.state.tipoMovimentacao} onChange={this.setTipoMovimentacao}>
                            <option value="true">Entrada</option>
                            <option value="false">Saida</option>
                        </select>
                    </div>
                    <div className="form-group" >
                        <label>Valor</label>
                        <input type="text" className="form-control" name="valor" value={this.state.valor} onChange={this.setValor} />
                    </div>
                    <div className="form-group" >
                        <label>Descrição</label>
                        <input type="text" className="form-control" name="descricao" value={this.state.descricao} onChange={this.setDescricao} />
                    </div>

        

                    </div>
                    <br></br>




                    <div className="row">
                        <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
                    </div>
                    <div className="col-4"></div>

            </Layout>);
    }
}

