import React from "react";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import CadastroCliente from "../Clientes/CadastroCliente";
import ListaClientes from "../Clientes/ListaClientes";
import ListaSabores from "../Sabores/ListaSabores";
import CadastroSabores from "../Sabores/CadastroSabores"
import NaoEncontrado from '../404/NaoEncontrado';

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
import ListaCaixa from "../Caixa/ListaCaixa";
import UsuarioPermissoes from "../Usuarios/UsuarioPermissoes"
import UsuarioGruposPermissoes from "../Usuarios/UsuarioGruposPermissoes"

import EditarAcompanhamento from "../Acompanhamentos/EditarAcompanhamento";
import ListaRelatorioEstoque from "../Estoque/ListaRelatorioEstoque";
import ListaGrupoUsuario from "../GrupoUsuario/ListaGrupoUsuario";
import ListaPermissao from "../Permissao/ListaPermissao";


import CadastroPermissao from "../Permissao/CadastroPermissao";
import EditarPermissao from "../Permissao/EditarPermissao";



import CadastroGrupoUsuario from "../GrupoUsuario/CadastroGrupoUsuario";
import EditarGrupoUsuario from "../GrupoUsuario/EditarGrupoUsuario";
import PermissoesGrupoUsuario from "../GrupoUsuario/PermissoesGrupoUsuario";
import Login from "../Login/Login";
import { isAuthenticated, isAutorizado } from '../Conexao/Conexao'
import NaoAutorizado from "../404/NaoAutorizado";
import Vendas from "../Vendas/Vendas";
import ListaVendas from "../Vendas/ListaVendas";

const Routes = () => (
    <BrowserRouter>
        <Switch>

            <Route path="/Login" component={Login} />

                <RotaProtegida role="cadastrarNovoCliente" path="/CadastroCliente" component={CadastroCliente} />
                <RotaProtegida role="cadastrarNovoSabor" path="/CadastroSabores"component={CadastroSabores}/>
                <RotaProtegida role="cadastrarNovoEstoque" path="/Estoque"component={Estoque}/>
                <RotaProtegida role="acessarListaEstoque" path="/ListaRelatorioEstoque" component={ListaRelatorioEstoque}/>
                <RotaProtegida role="cadastrarNovaCasquinha" path="/CadastroCasquinha" component={CadastroCasquinha} />
                <RotaProtegida role="cadastrarNovoUsuarios" path="/CadastroUsuario" component={CadastroUsuario} />
                <RotaProtegida role="cadastrarNovoAcompanhamento" path="/CadastroAcompanhamento" component={CadastroAcompanhamento} />
                <RotaProtegida role="cadastrarNovoAdicional" path="/CadastroAdicional" component={CadastroAdicional} />
                <RotaProtegida role="editarCliente" path="/EditarCliente/:id" component={EditarCliente}/>
                <RotaProtegida role="editarAcompanhamento" path="/EditarAcompanhamento/:id" component={EditarAcompanhamento}/>
                <RotaProtegida role="editarSabores" path="/EditarSabores/:id" component={EditarSabores}/>
                <RotaProtegida role="editarCasquinhas" path="/EditarCasquinha/:id" component={EditarCasquinha} />
                <RotaProtegida role="editarUsuarios" path="/EditarUsuario/:id" component={EditarUsuario}/>
                <RotaProtegida role="editarAdicional" path="/EditarAdicional/:id" component={EditarAdicional} />
                <RotaProtegida role="acessarListaCliente" path="/ListaClientes" component={ListaClientes} />
                <RotaProtegida role="acessarListaSabores" path="/ListaSabores"component={ListaSabores}/>
                <RotaProtegida role="acessarListaCasquinhas" path="/ListaCasquinha" component={ListaCasquinha} />
                <RotaProtegida role="acessarListaUsuarios" path="/ListaUsuarios" component={ListaUsuario} />
                <RotaProtegida role="acessarListaAcompanhamentos" path="/ListaAcompanhamentos" component={ListaAcompanhamentos} />
                <RotaProtegida role="acessarListaAdicional" path="/ListaAdicional" component={ListaAdicional} />
                <RotaProtegida role="acessarListaCaixa" path="/ListaCaixa" component={ListaCaixa} />
                <RotaProtegida role="acessarListaCaixa" path="/ControleCaixa" component={ControleCaixa} />
                <RotaProtegida role="cadastrarNovoPermissao" path="/CadastroPermissao" component={CadastroPermissao}/>
                <RotaProtegida role="editarPermissao" path="/EditarPermissao/:id" component={EditarPermissao}/>
                <RotaProtegida role="acessarListaPermissao" path="/Permissao" component={ListaPermissao}/>
                <RotaProtegida role="cadastrarNovoGrupoUsuario" path="/CadastroGrupoUsuario" component={CadastroGrupoUsuario}/>
                <RotaProtegida role="editarGrupoUsuario" path="/EditarGrupoUsuario/:id" component={EditarGrupoUsuario}/>
                <RotaProtegida path="/GrupoUsuario" component={ListaGrupoUsuario} role="acessarListaGrupoUsuario"></RotaProtegida>
                <RotaProtegida path="/GruposUsuario/:id" component={UsuarioGruposPermissoes} role="acessarListaUsuarioGrupoUsuarios"></RotaProtegida>
                <RotaProtegida path="/PermissoesUsuario/:id" component={UsuarioPermissoes} role="acessarListaUsuariosPermissao"></RotaProtegida>
                <RotaProtegida path="/PermissoesGrupoUsuario/:id" component={PermissoesGrupoUsuario} role="acessarListaGrupoUsuarioPermissao"></RotaProtegida>
                <Route exact path="/" component={Vendas} />
                <Route exact path="/Vendas" component={ListaVendas} />
                <Route path="/Logoff" component={() => <Redirect to="/Login"></Redirect>} />
                <Route path="/NaoAutorizado" component={NaoAutorizado} />
                <Route path="*" component={NaoEncontrado} />
                


        </Switch>

    </BrowserRouter>

);

export default Routes;

export const RotaProtegida = (Props) => (
    isAuthenticated() ?

        isAutorizado(Props.role) ?
            <Route path={Props.path} component={Props.component}></Route>
            :
            <Redirect to="/NaoAutorizado" />  
        :
        <Redirect to="/Login" />
)


