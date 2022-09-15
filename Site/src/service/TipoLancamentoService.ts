import { Injectable } from '@angular/core';
import axios from 'src/infrastructure/http-client';
import { TipoLancamento } from 'src/model/TipoLancamento';

@Injectable({
  providedIn: 'root'
})
export class TipoLancamentoService {
  private _Url = 'api/TiposLancamentos';

  constructor() { }

  async getAll():Promise<TipoLancamento[]> {
    try{
      const { data } = await axios
                              .get<TipoLancamento[]>(
                                this._Url
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return [];
    }
  }

  async getFind(id: string):Promise<TipoLancamento> {
    try{
      const { data } = await axios
                              .get<TipoLancamento>(
                                `${this._Url}/${id}`
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

}
