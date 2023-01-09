import { UsuarioInsert } from 'src/model/UsuarioInsert';
import { UsuarioRecuperaSenha } from 'src/model/UsuarioRecuperaSenha';
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
      console.log(data)
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

  async AtualizarSenhaUsuario(id: string,
                              user: UsuarioRecuperaSenha):Promise<Usuario> {
    try{
      const { data } = await axios
                              .put<Usuario>(
                                `${this._Url}/${id}/AlterarSenha`
                                , user
                              );
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

  async CriaUsuario(
        user: UsuarioInsert
      ):Promise<Usuario> {
    try{
    const { data } = await axios
        .post<Usuario>(
          `${this._Url}`
          , user
        );
    return data;
    } catch (error) {
      console.log('error message: ', error);
    return {};
    }
  }


}
