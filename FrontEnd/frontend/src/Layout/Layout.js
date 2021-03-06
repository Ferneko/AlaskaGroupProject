import React, { Component } from 'react'
import './Layout.css';
import { Link } from "react-router-dom";


export default class extends Component {
    constructor(props) {
        super(props)
        this.logoff = this.logoff.bind(this)
    }
    logoff() {
        localStorage.clear()
        //Redirect("/Login")
        //alert(this.props)
        //this.props.history.push('/foo')
    }



    render() {
        return (<div>
            <nav className="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0">
                <div className="navbar-brand col-sm-3 col-md-2 mr-0" href="#">
                    Alaska Sorveteria
                </div>

                <ul className="navbar-nav px-3">
                    <li className="nav-item text-nowrap">
                        <Link to="/Logoff" onClick={this.logoff} className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span> Sair do sistema</Link>
                    </li>
                </ul>
            </nav>
            <div className="container-fluid">
                <div className="row">
                    <nav className="col-md-2 d-none d-md-block bg-light sidebar">
                        <div className="sidebar-sticky">
                            <ul className="nav flex-column">


                                <li className="nav-item">
                                    <Link to="/ListaAcompanhamentos" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Acompanhamentos</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/ListaAdicional" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Adicionais</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/ListaSabores" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Sabores</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/ListaClientes" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Clientes</Link>
                                </li>

                                <li className="nav-item">
                                    <Link to="/ListaCasquinha" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Casquinha</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/Estoque" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Movimentar Estoque</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/ListaRelatorioEstoque" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Relatório de Estoque</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/ControleCaixa" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Caixa</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/ListaCaixa" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Lista Caixa</Link>
                                </li>

                                <li className="nav-item">
                                    <Link to="/ListaUsuarios" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Usuários</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/Permissao" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Permissão</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/GrupoUsuario" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Grupo Usuário</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Vendas</Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/Vendas" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Todas as vendas</Link>
                                </li>
                            </ul>
                        </div>
                    </nav>
                    <main role="main" className="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
                        {this.props.children}
                    </main>
                </div>
            </div>
        </div>
        )
    }
}