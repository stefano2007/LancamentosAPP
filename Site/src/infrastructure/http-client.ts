import axios from 'axios';
import { Contrants } from 'src/utils/Contrants';
const instance = axios.create({
  baseURL: Contrants.API_LANCAMENTOS_PATH,
  headers: {
    Accept: 'application/json',
  }
});

export default instance;
