import { Injectable } from '@angular/core';
import axios from 'src/infrastructure/http-client';
import { Conta } from 'src/model/Conta';

@Injectable({
  providedIn: 'root'
})
export class ContaService {
  private _Url = 'api/Contas';

  constructor() { }

  async getAll():Promise<Conta[]> {
    try{
      const { data } = await axios
                              .get<Conta[]>(
                                this._Url
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return [];
    }
  }

  async getFind(id: string):Promise<Conta> {
    try{
      const { data } = await axios
                              .get<Conta>(
                                `${this._Url}/${id}`
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

}
