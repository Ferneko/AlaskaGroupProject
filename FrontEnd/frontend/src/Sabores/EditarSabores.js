import React, { Component } from 'react'
import Layout from '../Layout/Layout';
import Conexao from '../Conexao/Conexao';

export default class EditarSabores extends Component {
    constructor(props) {
        super(props)

        //console.log(props);
        //console.log(this.props.match.params.id);
        this.state = {
            id: this.props.match.params.id,
            name: "",
            description: "",
            price: "",
            ativo: true,
            erro: null
        }

        this.setName = this.setName.bind(this)
        this.setDescription = this.setDescription.bind(this)
        this.setPrice= this.setPrice.bind(this)
        this.setAtivo = this.setAtivo.bind(this)
        this.enviarParaBackEnd = this.enviarParaBackEnd.bind(this);
    }

    componentDidMount() {
        Conexao.get("/Sabores/" + this.state.id).then(resposta => {
            const dados = resposta.data;
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                this.setState({

                    id: dados.id,
                    name: dados.name,
                    description: dados.description,
                    price: dados.price,
                    ativo: dados.ativo
                });
            }
        });
    }

    setName(e) {
        this.setState({
            name: e.target.value,
        })
    }

    setDescription(e) {
        this.setState({
            description: e.target.value,
        })
    }
    setPrice(e) {
        this.setState({
            price: e.target.value,
        })
    }

    setAtivo(e) {
        this.setState({
            ativo: e.target.value === 'true' ? true : false
        });
    }
    enviarParaBackEnd() {
        console.log(this.state)
        Conexao.post("/Sabores", {
            id: this.state.id,
            name: this.state.name,
            description: this.state.description,
            price: Number(this.state.price),
            ativo: this.state.ativo

        }).then(resposta => {
            const dados = resposta.data;
            console.log(dados.erro)
            if (dados.erro != null) {
                this.setState({ erro: dados.erro });
            } else {
                //alert("deu");
                this.props.history.push('/ListaSabores')
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
                        <input type="text" className="form-control" id="name" name="name" value={this.state.name} onChange={this.setName} />
                    </div>
                    <div className="form-group" >
                        <label>Descricao</label>
                        <input type="text" className="form-control" id="description" name="description" value={this.state.description} onChange={this.setDescription} />
                    </div>
                    <div className="form-group" >
                        <label>Preço</label>
                        <input type="text" className="form-control" name="price" value={this.state.price} onChange={this.setPrice} />
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

