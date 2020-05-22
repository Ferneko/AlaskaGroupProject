import React from "react";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import CadastroCliente from "../Clientes/CadastroCliente";
import ListaClientes from "../Clientes/ListaClientes";
import NaoEncontrado from '../404/NaoEncontrado';
import Layout from '../Layout/Layout';
import CadastroUsuario from "../Usuarios/CadastroUsuario";
import ListaUsuario from "../Usuarios/ListaUsuarios";
const Routes = () => (
    <BrowserRouter>
        <Switch>
                <Route path="/CadastroCliente" component={CadastroCliente} />
                <Route path="/ListaClientes" component={ListaClientes} />
                <Route path="/CadastroUsuario" component={CadastroUsuario} />
                <Route path="/ListaUsuarios" component={ListaUsuario} />
                <Route exact path="/" component={() => <Layout><h1>Raiz do site</h1></Layout>} />
                <Route path="*" component={NaoEncontrado} />
                <Route path="/EditarUsuario/:id" component={EditarUsuario}/>

        </Switch>

    </BrowserRouter>

);

export default Routes;