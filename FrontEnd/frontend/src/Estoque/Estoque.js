import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";

export default class Estoque extends Component {

    constructor(props) {
        super(props)

        this.state = {


            data: new Date(),
            tipoMovimentacao: 1,//entrada ==1 saida ==0
            casquinhaId: "",
            quantidadeCasquinha: 0,
            adicionalid: "",
            quantidadeAdicional: 0,
            acompanhamentoId: "",
            quantidadeAcompanhamento: 0,
            saboresid: "",
            quantidadeSabores: 0,
            erro: null,
            todasCasquinhas: [],
            todosAdicionais: [],
            todosAcompanhamentos: [],
            todosSabores: [],
            estoqueCasquinha: 0
        }

        //this.setId= this.setId.bind(this)
        this.setData = this.setData.bind(this)
        this.setTipoMovimentacao = this.setTipoMovimentacao.bind(this)
        this.setCasquinhaid = this.setCasquinhaid.bind(this)
        this.setQuantidadeCasquinha = this.setQuantidadeCasquinha.bind(this)
        this.setAdicionalid = this.setAdicionalid.bind(this)
        this.setQuantidadeAdicional = this.setQuantidadeAdicional.bind(this)
        this.setAcompanhamentoid = this.setAcompanhamentoid.bind(this)
        this.setQuantidadeAcompanhamento = this.setQuantidadeAcompanhamento.bind(this)
        this.setSaboresid = this.setSaboresid.bind(this)
        this.setQuantidadeSabores = this.setQuantidadeSabores.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
        this.getEstoqueCasquinha = this.getEstoqueCasquinha.bind(this)
    }

    componentDidMount() {


        Conexao.get("/Estoque/NovaEntrada").then(resposta => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({

                    todasCasquinhas: dados.todasCasquinhas,
                    casquinhaId: dados.todasCasquinhas[0].id,

                    todosAdicionais: dados.todosAdicionais,
                    adicionalid: dados.todosAdicionais[0].id,

                    todosAcompanhamentos: dados.todosAcompanhamentos,
                    acompanhamentoId: dados.todosAcompanhamentos[0].id,

                    todosSabores: dados.todosSabores,
                    saboresid: dados.todosSabores[0].id
                });
            }
        });
    }

    componentDidMount() {


        Conexao.get("/Estoque/NovaEntrada").then(resposta => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({

                    todasCasquinhas: dados.todasCasquinhas,
                    casquinhaId: dados.todasCasquinhas[0].id,

                    todosAdicionais: dados.todosAdicionais,
                    adicionalid: dados.todosAdicionais[0].id,

                    todosAcompanhamentos: dados.todosAcompanhamentos,
                    acompanhamentoId: dados.todosAcompanhamentos[0].id,

                    todosSabores: dados.todosSabores,
                    saboresid: dados.todosSabores[0].id
                });
            }
        });
    }

    getEstoqueCasquinha(idCasquinha) {


        Conexao.get("/Estoque/SaldoCasquinha/" + this.state.casquinhaId).then(resposta => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({

                    estoqueCasquinha: dados
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

        let arrayValores = [this.state.quantidadeCasquinha, this.state.quantidadeAdicional, this.state.quantidadeAcompanhamento, this.state.quantidadeSabores]
        var i = 0;
        if (Number(e.target.value) === 1) {

            for (i = 0; i < arrayValores.length; i++) {
                if (arrayValores[i] < 0) {
                    arrayValores[i] = arrayValores[i] * -1;
                }
            }

        } else {

            for (i = 0; i < arrayValores.length; i++) {
                if (arrayValores[i] > 0) {
                    arrayValores[i] = arrayValores[i] * -1;
                }
            }
        }

        this.setState({
            tipoMovimentacao: Number(e.target.value),
            quantidadeCasquinha: arrayValores[0],
            quantidadeAdicional: arrayValores[1],
            quantidadeAcompanhamento: arrayValores[2],
            quantidadeSabores: arrayValores[3]
        });


        this.setState({
            tipoMovimentacao: e.target.value
        });
    }

    setCasquinhaid(e) {
       this.getEstoqueCasquinha(e.target.value)
        this.setState({
            casquinhaId: e.target.value,
        })
    }
    setQuantidadeCasquinha(e) {
        this.setState({
            quantidadeCasquinha: e.target.value,
        })
    }
    setAdicionalid(e) {
        this.setState({
            adicionalid: e.target.value,
        })
    }
    setQuantidadeAdicional(e) {
        this.setState({
            quantidadeAdicional: e.target.value,
        })
    }
    setAcompanhamentoid(e) {
        this.setState({
            acompanhamentoId: e.target.value,
        })
    }
    setQuantidadeAcompanhamento(e) {
        this.setState({
            quantidadeAcompanhamento: e.target.value,
        })
    }
    setSaboresid(e) {
        this.setState({
            saboresid: e.target.value,
        })
    }
    setQuantidadeSabores(e) {
        this.setState({
            quantidadeSabores: e.target.value,
        })
    }


    enviarParaBackEnd() {
        console.log(this.state)
        let enviarDados = {

            data: this.state.data,

            tipoMovimentacao: this.state.tipoMovimentacao,

            casquinhaId: Number(this.state.casquinhaId),
            quantidadeCasquinha: Number(this.state.quantidadeCasquinha),

            adicionalId: Number(this.state.adicionalid),
            quantidadeAdicional: Number(this.state.quantidadeAdicional),

            acompanhamentoId: Number(this.state.acompanhamentoId),
            quantidadeAcompanhamento: Number(this.state.quantidadeAcompanhamento),

            saboresId: Number(this.state.saboresid),
            quantidadeSabores: Number(this.state.quantidadeSabores),


        }
        console.log(enviarDados)
        Conexao.post("/Estoque", enviarDados).then(resposta => {
            // console.log('entrou aqui');
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {

                this.props.history.push('/ListaRelatorioEstoque')
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

                    <div className="form-group col-md-3">
                        <label>Data</label><br />
                        <DatePicker className="form-control" style={{ width: '100%' }}
                            selected={this.state.data}
                            onChange={this.setData}
                        />

                    </div>


                    <div className="form-group col-md-3">
                        <label> Tipo de Movimentação </label>
                        <select className="form-control" defaultValue={this.state.tipoMovimentacao} onChange={this.setTipoMovimentacao}>

                            <option value="1">Entrada</option>
                            <option value="0">Saída</option>
                        </select>
                    </div>
                </div>

                <div className="row">
                    <div className="form-group col-md-3">
                        <label>Casquinha</label>
                        <select className="form-control" name="casquinhaid" value={this.state.casquinhaId} onChange={this.setCasquinhaid}>
                            {this.state.todasCasquinhas.map((item) => (
                                <option key={item.id} value={item.id}>{item.nome}</option>
                            ))}
                        </select>
                        {this.state.estoqueCasquinha} em estoque
                    </div>

                    <div className="form-group col-md-3">
                        <label>Qtd Casquinha</label>
                        <input type="number" min="0" className="form-control" name="quantidadecasquinha" value={this.state.quantidadeCasquinha} onChange={this.setQuantidadeCasquinha} />
                    </div>

                </div>

                <div className="row">

                    <div className="form-group col-md-3">
                        <label>Adicional</label>

                        <select className="form-control" name="adicionalid" defaultValue={this.state.Adicionalid} onChange={this.setAdicionalid}>
                            {this.state.todosAdicionais.map((item) => (
                                <option key={item.id} value={item.id}>{item.nome}</option>
                            ))}
                        </select>
                    </div>

                    <div className="form-group col-md-3">
                        <label>Qtd Adicional</label>
                        <input type="number" min="0" className="form-control" name="quantidadeAdicional" value={this.state.quantidadeAdicional} onChange={this.setQuantidadeAdicional} />
                    </div>
                </div>

                <div className="row">
                    <div className="form-group col-md-3">
                        <label>Acompanhamento</label>

                        <select className="form-control" name="acompanhamentoId" defaultValue={this.state.acompanhamentoId} onChange={this.setAcompanhamentoid}>
                            {this.state.todosAcompanhamentos.map((item) => (
                                <option key={item.id} value={item.id}>{item.nome}</option>
                            ))}
                        </select>
                    </div>


                    <div className="form-group col-md-3">
                        <label>Qtd Acompanhamento</label>
                        <input type="number" min="0" className="form-control" name="quantidadeAcompanhamento" value={this.state.quantidadeAcompanhamento} onChange={this.setQuantidadeAcompanhamento} />
                    </div>
                </div>

                <div className="row">
                    <div className="form-group col-md-3">
                        <label>Sabor</label>
                        <select className="form-control" name="saborid" defaultValue={this.state.saboresid} onChange={this.setSaboresid}>
                            {this.state.todosSabores.map((item) => (
                                <option key={item.id} value={item.id}>{item.name}</option>
                            ))}
                        </select>
                    </div>

                    <div className="form-group col-md-3">
                        <label>Qtd Sabor</label>
                        <input type="number" min="0" className="form-control" name="quantidadeSabor" value={this.state.quantidadeSabores} onChange={this.setQuantidadeSabores} />
                    </div>
                </div>

                <br></br>

                <div className="row">
                    <button className="btn btn-success" onClick={this.enviarParaBackEnd}>Salvar</button>
                </div>




            </Layout>);
    }
}

/*

 let dia = new Date().getDay();
        console.log(dia+" Dia");

        let mes = new Date().getMonth()+1;
        console.log(mes+" mes");

        let ano = new Date().getFullYear();
        console.log(ano+" ano");

        //let dataAgora = +"/"+new Date(Date.now()).getMonth()+"/"+new Date(Date.now()).getFullYear()
        let dataAgora = dia+"-"+mes+"-"+ano;
        //console.log(new Date(dataAgora).getDay());
        console.log(dataAgora);
        document.getElementById("data").value = "2014-02-09";
        //this.dateInput.current.value = dataAgora;
 <input type="date" className="form-control" ref={this.dateInput} id="data" name="data" value={this.state.data} onChange={this.setData} />
        */