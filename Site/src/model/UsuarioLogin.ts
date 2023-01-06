export class UsuarioLogin {
  email?: string;
  //login?: string;
  nome?: string;
  usuarioId?: number;
  token?: string;
  expires?: Date;

  constructor(values: UsuarioLogin) {
      Object.assign(this, values);
  }
}
