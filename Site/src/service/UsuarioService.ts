import { Injectable } from '@angular/core';
import axios from 'src/infrastructure/http-client';
import { Usuario } from 'src/model/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private _Url = 'api/Usuarios';

  constructor() { }

  async getAll():Promise<Usuario[]> {
    try{
      const { data } = await axios
                              .get<Usuario[]>(
                                this._Url
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return [];
    }
  }

  async getFind(id: string):Promise<Usuario> {
    try{
      const { data } = await axios
                              .get<Usuario>(
                                `${this._Url}/${id}`
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

}
