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

  async Inserir(lancamento :Lancamento){
    console.log("lancamento", lancamento);
    try{
      const { data } = await axios
                              .post<Lancamento>(
                                `${this._Url}`,
                                lancamento
                              );
      console.log(data);
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

  async Atualizar(id:string, lancamento :Lancamento){
    try{
      const { data } = await axios
                              .put<Lancamento>(
                                `${this._Url}/${id}`,
                                lancamento
                              );
      console.log(data);
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

}
