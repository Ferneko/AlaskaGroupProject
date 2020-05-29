import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';

export default class Estoque extends Component {
    constructor(props) {
        super(props)
        this.state = {

            id: this.props.match.params.id,
            data: "",
            tipo: "",
            tipoMovimentacao: "",//entrada ==1 saida ==0
            casquinhaid:"",
            quantidadeCasquinha:"",
            adicionalid:"",
            quantidadeAdicional:"",
            acompanhamentoid:"",
            quantidadeAcompanhamento:"",
            saboresid:"",
            quantidadeSabores:"",
            erro: null
        }

        //this.setId= this.setId.bind(this)
        this.setData= this.setData.bind(this)
        this.setTipo = this.setTipo.bind(this)
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

    }
    componentDidMount() {
        Conexao.get("/Estoque/" + this.state.id).then(resposta => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({

                    id: dados.id,
                    data: dados.data,
                    tipo: dados.tipo,
                    tipoMovimentacao: dados.tipoMovimentacao,
                    casquinhaid:dados.casquinhaid,
                    quantidadeCasquinha:dados.quantidadeCasquinha,
                    adicionalid:dados.adicionalid,
                    quantidadeAdicional:dados.quantidadeAdicional,
                    acompanhamentoid:dados.acompanhamentoid,
                    quantidadeAcompanhamento:dados.quantidadeAcompanhamento,
                    saboresid:dados.saboresid,
                    quantidadeSabores:dados.quantidadeSabores,
                    
                  

                });
            }
        });
    }


    setData(e) {
        this.setState({
            data: e.target.value,
        })

    }

    setTipo(e) {
        this.setState({
            tipo: e.target.value,
        })
    }

    setTipoMovimentacao(e) {
        this.setState({
            tipoMovimentacao: e.target.value === 'true' ? true : false
        });
    }

    setCasquinhaid(e) {
        this.setState({
            casquinhaid: e.target.value,
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
            acompanhamentoid: e.target.value,
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
  
    //setAtivo(e) {
       // this.setState( {
       //ativo: e.target.value === 'true' ? true : false
       // });
   // }
    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Estoque", { 
            id: this.state.id,
            data: this.state.data,
            tipo: this.state.tipo,
            tipoMovimentacao: this.state.tipoMovimentacao,//entrada ==1 saida ==0
            casquinhaid: this.state.casquinhaid,
            quantidadeCasquinha: this.state.quantidadeCasquinha,
            adicionalid: this.state.adicionalid,
            quantidadeAdicional: this.state.quantidadeAdicional,
            acompanhamentoid: this.state.acompanhamentoid,
            quantidadeAcompanhamento: this.state.quantidadeAcompanhamento,
            saboresid: this.state.saboresid,
            quantidadeSabores: this.state.quantidadeSabores,
            //ativo: this.state.ativo,

         }).then(resposta => {
            // console.log('entrou aqui');
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
               
                this.props.history.push('/Estoque')//nao sei ainda oque fazer aqui
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
                  
                    
                    <div class="row">
                        <div className="form-group" class="col-md-3" >
                            <label>Código</label>
                            <input type="text" className="form-control" id="id" name="id" value={this.state.id} onChange={this.setid} />
                        </div>
                       
                        
                        <div className="form-group" class="col-md-3">
                            <label>Data</label>
                            <input type="date" className="form-control" id="data" name="date" value={this.state.data} onChange={this.setData} />
                        </div>
                        
                        <div className="form-group" class="col-md-3">
                            <label>Tipo</label>
                            <input type="text" className="form-control" name="tipo" value={this.state.tipo} onChange={this.setTipo} />
                       </div>
                     

                       
                    <div className="form-group " class="col-md-3">
                            <label> Tipo de Movimentação </label>
                            <select className="form-control" value={this.state.tipoMovimentacao} onChange={this.setTipoMovimentacao}>
                               
                                <option value="true">Entrada</option>
                                <option value="false">Saída</option>
                            </select>
                        </div>
                        </div>

                        <div class="row">
                    <div className="form-group" class="col-md-3">
                            <label>Código Casquinha</label>
                            <input type="text" className="form-control" name="casquinhaid" value={this.state.casquinhaid} onChange={this.setCasquinhaid} />
                       </div>

                       <div className="form-group" class="col-md-3">
                            <label>Qtd Casquinha</label>
                            <input type="number" className="form-control" name="quantidadecasquinha" value={this.state.QuantidadeCasquinha} onChange={this.setQuantidadeCasquinha} />
                       </div>
                      

                      
                       <div className="form-group" class="col-md-3">
                            <label>Código Adicional</label>
                            <input type="text" className="form-control" name="adicionalid" value={this.state.Adicionalid} onChange={this.setAdicionalid} />
                       </div>

                       <div className="form-group" class="col-md-3">
                            <label>Qtd Adicional</label>
                            <input type="number" className="form-control" name="quantidadeAdicional" value={this.state.QuantidadeAdicional} onChange={this.setQuantidadeAdicional} />
                       </div>
                       </div>

                       <div class="row">
                       <div className="form-group" class="col-md-3">
                            <label>Código Acompanhamento</label>
                            <input type="text" className="form-control" name="acompanhamentoid" value={this.state.acompanhamentoid} onChange={this.setAcompanhamentoid} />
                       </div>
                       

                       <div className="form-group" class="col-md-3">
                            <label>Qtd Acompanhamento</label>
                            <input type="number" className="form-control" name="quantidadeAcompanhamento" value={this.state.QuantidadeAcompanhamento} onChange={this.setQuantidadeAcompanhamento} />
                       </div>

                       <div className="form-group" class="col-md-3" >
                            <label>Código Sabor</label>
                            <input type="text" className="form-control" name="saborid" value={this.state.saboresid} onChange={this.setSaboresid} />
                       </div>

                       <div className="form-group" class="col-md-3">
                            <label>Qtd Sabor</label>
                            <input type="number" className="form-control" name="quantidadeSabor" value={this.state.quantidadeSabores} onChange={this.setQuantidadeSabores} />
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

