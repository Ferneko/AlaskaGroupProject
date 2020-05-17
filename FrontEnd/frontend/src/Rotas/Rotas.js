import React from "react";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import CadastroCliente from "../Clientes/CadastroCliente";
import ListaClientes from "../Clientes/ListaClientes";
import ListaSabores from "../Sabores/ListaSabores";
import CadastroSabores from "../Sabores/CadastroSabores"
import NaoEncontrado from '../404/NaoEncontrado';
import Layout from '../Layout/Layout';
import ListaCasquinha from "../Casquinha/ListaCasquinha";
import CadastroCasquinha from "../Casquinha/CadastroCasquinha";
import CadastroUsuario from "../Usuarios/CadastroUsuario";
import ListaUsuario from "../Usuarios/ListaUsuarios";
const Routes = () => (
    <BrowserRouter>
        <Switch>
                <Route path="/CadastroCliente" component={CadastroCliente} />
                <Route path="/ListaClientes" component={ListaClientes} />
                <Route path="/CadastroSabores"component={CadastroSabores}/>
                <Route path="/ListaSabores"component={ListaSabores}/>
                <Route path="/CadastroCasquinha" component={CadastroCasquinha} />
                <Route path="/ListaCasquinha" component={ListaCasquinha} />
                <Route path="/CadastroUsuario" component={CadastroUsuario} />
                <Route path="/ListaUsuarios" component={ListaUsuario} />
                <Route exact path="/" component={() => <Layout><h1>Raiz do site</h1></Layout>} />
                <Route path="*" component={NaoEncontrado} />
        </Switch>
    </BrowserRouter>
);

export default Routes;