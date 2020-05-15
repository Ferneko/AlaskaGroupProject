import React, { Component } from 'react'
import './Layout.css';
import { Link } from "react-router-dom";
export default class extends Component {
    constructor(props){
        super(props);
    }
    render() {
        return (<div>
            <nav className="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0">
                <a className="navbar-brand col-sm-3 col-md-2 mr-0" href="#">Sorveteria Alaska</a>
              
                <ul className="navbar-nav px-3">
                    <li className="nav-item text-nowrap">
                        <a className="nav-link" href="#">Sair do sistema</a>
                    </li>
                </ul>
            </nav>

            <div className="container-fluid">
                <div className="row">
                    <nav className="col-md-2 d-none d-md-block bg-light sidebar">
                        <div className="sidebar-sticky">
                            <ul className="nav flex-column">
                                <li className="nav-item">
                                    <a className="nav-link active" href="#">
                                        <span data-feather="home"></span>
                        Casquinhas <span className="sr-only">(current)</span>
                                    </a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#">
                                        <span data-feather="file"></span>
                        Acompanhamentos
                      </a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#">
                                        <span data-feather="shopping-cart"></span>
                        Adicionais
                      </a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link" href="#">
                                        <span data-feather="users"></span>
                        Sabores
                      </a>
                                </li>
                                <li className="nav-item">
                                <Link to="/ListaClientes" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Clientes</Link>
                                </li>
                                
                                <li className="nav-item">
                                <Link to="/ListaUsuarios" className="nav-link" style={{ cursor: 'pointer' }}> <span data-feather="layers"></span>Usuários</Link>
                                   
                                       
                        
                      
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