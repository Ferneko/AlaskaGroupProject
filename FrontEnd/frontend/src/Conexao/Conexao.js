import axios from "axios";

const Conexao = axios.create({
  baseURL: "https://localhost:5001/api"
});

Conexao.interceptors.request.use(async config => {
  const token = localStorage.getItem('tokenJWT');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default Conexao;


export const isAuthenticated = () => {
    if(localStorage.getItem('tokenJWT') === null)
    {
        return false;
    }
    else {
      return true;
    }
}
  



export const isAutorizado = (role) => {

    if(localStorage.getItem(role) === null )
    {
      return false
    }
    else
    {
      return true
    }
  

}

export const logoff = () => {
  localStorage.clear()
}