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