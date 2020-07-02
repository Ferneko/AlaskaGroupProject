import React, { Component } from 'react'
import Layout from '../Layout/Layout';
export default class NaoAutorizado extends Component {
    render(){
        return(
            <Layout>
                <h1> Erro 401 - Você não tem permissão para acessar essa funcionalidade</h1>
            </Layout>
        )
    }
}