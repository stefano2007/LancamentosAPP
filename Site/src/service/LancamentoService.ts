import { Injectable } from '@angular/core';
import axios from 'src/infrastructure/http-client';
import { Lancamento } from 'src/model/Lancamento';

@Injectable({
  providedIn: 'root'
})
export class LancamentoService {
  private _Url = 'api/Lancamentos';

  constructor() { }

  async getAll():Promise<Lancamento[]> {
    try{
      const { data } = await axios
                              .get<Lancamento[]>(
                                this._Url
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return [];
    }
  }

  async getFind(id: string):Promise<Lancamento> {
    try{
      const { data } = await axios
                              .get<Lancamento>(
                                `${this._Url}/${id}`
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

}
