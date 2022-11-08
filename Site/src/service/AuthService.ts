import { Injectable } from '@angular/core';
import * as moment from 'moment';
import axios from 'src/infrastructure/http-client';
import { UsuarioLogin } from 'src/model/UsuarioLogin';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _Url = 'api/Auth';

  constructor() { }

  async login(email:string, password:string ):Promise<UsuarioLogin> {
    try{
      const { data } = await axios
                              .post<UsuarioLogin>(
                                this._Url,
                                { email , senha: password }
                              );
      await this.setSession(data);
      return data;
    } catch (error) {
      console.log('error message: ', error);
      return {};
    }
  }

  private async setSession(authResult : UsuarioLogin) {
    let expires = authResult.expires;
    const expiresAt = moment(expires);

    let token = authResult.token || "";
    localStorage.setItem('access_token', token);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));

    localStorage.setItem("usuario_logado", JSON.stringify(authResult));
  }

  logout() {
      localStorage.removeItem("access_token");
      localStorage.removeItem("expires_at");
      localStorage.removeItem("usuario_logado");
  }

  public isLoggedIn() {
      return moment().isBefore(this.getExpiration()) && this.getToken();
  }

  public getToken():string{
    return localStorage.getItem("access_token") || "";
  }

  isLoggedOut() {
      return !this.isLoggedIn();
  }

  getExpiration() {
      const expiration = localStorage.getItem("expires_at")||"0";
      const expiresAt = JSON.parse(expiration);
      return moment(expiresAt);
  }

  getUsuario(): UsuarioLogin{
    const usuarioLogado = localStorage.getItem("usuario_logado") || "";
    if(usuarioLogado)
      return JSON.parse(usuarioLogado)

    return {};
  }

  getNomeUsuario(): string{
    let usuarioLogado: UsuarioLogin= this.getUsuario();

    return usuarioLogado.nome || "-";
  }
}
