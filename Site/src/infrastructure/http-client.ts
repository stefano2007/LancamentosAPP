import axios from 'axios';
import { Contrants } from 'src/utils/Contrants';
const instance = axios.create({
  baseURL: Contrants.API_LANCAMENTOS_PATH,
  headers: {
    Accept: 'application/json',
  }
});

// Request interceptor for API calls
instance.interceptors.request.use(
  async config => {
    console.log('instance.interceptors.request.use');
    const access_token = localStorage.getItem("access_token");

    if(access_token){
      config.headers = {
        'Authorization': `Bearer ${access_token}`,
        'Accept': 'application/json'
      }
    }
    return config;
  },
  error => {
    Promise.reject(error)
});

instance.interceptors.response.use(
  (response) => {
    return response;
  },
  async function (error) {
    /*const access_token = localStorage.getItem("access_token");
    if (error.response.status === 401 && access_token) {
      //const response = await refreshToken(error);
      //return response;
    }*/

    console.log('instance.interceptors.response.use erro', error)
    return Promise.reject(error);
  }
);

export default instance;
