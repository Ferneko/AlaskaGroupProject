import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import CadastroCliente from "../Clientes/CadastroCliente";
import ListaClientes from "../Clientes/ListaClientes";
import ListaSabores from "../Sabores/ListaSabores";
import CadastroSabores from "../Sabores/CadastroSabores"
import NaoEncontrado from '../404/NaoEncontrado';
import Layout from '../Layout/Layout';
import EditarCasquinha from "../Casquinha/EditarCasquinha";
import ListaCasquinha from "../Casquinha/ListaCasquinha";
import CadastroCasquinha from "../Casquinha/CadastroCasquinha";
import CadastroUsuario from "../Usuarios/CadastroUsuario";
import ListaUsuario from "../Usuarios/ListaUsuarios";
import ListaAcompanhamentos from "../Acompanhamentos/ListaAcompanhamentos";
import CadastroAcompanhamento from "../Acompanhamentos/CadastroAcompanhamento";
import ListaAdicional from "../Adicional/ListaAdicional";
import CadastroAdicional from "../Adicional/CadastroAdicional";
import EditarCliente from "../Clientes/EditarCliente";
import EditarSabores from "../Sabores/EditarSabores";
import EditarUsuario from "../Usuarios/EditarUsuario";
import EditarAdicional from "../Adicional/EditarAdicional";
import ControleCaixa from "../Caixa/ControleCaixa";
import Estoque from "../Estoque/Estoque";
import ListaRelatorioCaixa from "../Caixa/ListaRelatorioCaixa";
import EditarAcompanhamento from "../Acompanhamentos/EditarAcompanhamento";
import ListaRelatorioEstoque from "../Estoque/ListaRelatorioEstoque";

import Permissao from "../Permissao/CadastroPermissao";
import CadastroPermissao from "../Permissao/CadastroPermissao";
import EditarPermissao from "../Permissao/EditarPermissao";
import ListaRelatorioPermissao from "../Permissao/ListaRelatorioPermissao";

import GrupoUsuario from "../GrupoUsuario/CadastroGrupoUsuario";
import CadastroGrupoUsuario from "../GrupoUsuario/CadastroGrupoUsuario";
import EditarGrupoUsuario from "../GrupoUsuario/EditarGrupoUsuario";
import ListaRelatorioGrupoUsuario from "../GrupoUsuario/ListaRelatorioGrupoUsuario";

const Routes = () => (
    <BrowserRouter>
        <Switch>

            <Route path="/CadastroCliente" component={CadastroCliente}/>
            <Route path="/CadastroSabores"component={CadastroSabores}/>
          
            <Route path="/Estoque"component={Estoque}/>
            <Route path="/ListaRelatorioEstoque" component={ListaRelatorioEstoque}/>
                
            <Route path="/CadastroCasquinha" component={CadastroCasquinha}/>
            <Route path="/CadastroUsuario" component={CadastroUsuario}/>
            <Route path="/CadastroAcompanhamento" component={CadastroAcompanhamento}/>
            <Route path="/CadastroAdicional" component={CadastroAdicional}/>

            <Route path="/EditarCliente/:id" component={EditarCliente}/>
            <Route path="/EditarAcompanhamento/:id" component={EditarAcompanhamento}/>
            <Route path="/EditarSabores/:id" component={EditarSabores}/>
            <Route path="/EditarCasquinha/:id" component={EditarCasquinha}/>
            <Route path="/EditarUsuario/:id" component={EditarUsuario}/>
            <Route path="/EditarAdicional/:id" component={EditarAdicional}/>
              
            <Route path="/ListaClientes" component={ListaClientes}/>
            <Route path="/ListaSabores"component={ListaSabores}/>
            <Route path="/ListaCasquinha" component={ListaCasquinha}/>
            <Route path="/ListaUsuarios" component={ListaUsuario}/>
            <Route path="/ListaAcompanhamentos" component={ListaAcompanhamentos}/>
            <Route path="/ListaAdicional" component={ListaAdicional}/>
              
            <Route path="/ListaRelatorioCaixa" component={ListaRelatorioCaixa}/>
            <Route path="/ControleCaixa" component={ControleCaixa}/>

            <Route path="/Permissao"component={Permissao}/>
            <Route path="/CadastroPermissao" component={CadastroPermissao}/>
            <Route path="/EditarPermissao/:id" component={EditarPermissao}/>
            <Route path="/ListaRelatorioPermissao" component={ListaRelatorioPermissao}/>

            <Route path="/GrupoUsuario"component={GrupoUsuario}/>
            <Route path="/CadastroGrupoUsuario" component={CadastroGrupoUsuario}/>
            <Route path="/EditarGrupoUsuario/:id" component={EditarGrupoUsuario}/>
            <Route path="/ListaRelatorioGrupoUsuario" component={ListaRelatorioGrupoUsuario}/>

            <Route exact path="/" component={() => <Layout></Layout>}/>
            <Route path="*" component={NaoEncontrado}/>
                
        </Switch>
    </BrowserRouter>
);
 
export default Routes;