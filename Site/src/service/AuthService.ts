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
    localStorage.setItem('id_token', token);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()) );
}

logout() {
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
}

public isLoggedIn() {
    return moment().isBefore(this.getExpiration());
}

isLoggedOut() {
    return !this.isLoggedIn();
}

getExpiration() {
    const expiration = localStorage.getItem("expires_at")||"";
    const expiresAt = JSON.parse(expiration);
    return moment(expiresAt);
}


}
