import { Injectable } from '@angular/core';
import axios from 'src/infrastructure/http-client';
import { TipoConta } from 'src/model/TipoConta';

@Injectable({
  providedIn: 'root'
})
export class TipoContaService {
  private _Url = 'api/TiposContas';

  constructor() { }

  async getAll():Promise<TipoConta[]> {
    try{
      const { data } = await axios
                              .get<TipoConta[]>(
                                this._Url
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return [];
    }
  }

  async getFind(id: string):Promise<TipoConta> {
    try{
      const { data } = await axios
                              .get<TipoConta>(
                                `${this._Url}/${id}`
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

}
