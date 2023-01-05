export class UsuarioRecuperaSenha {
  email?: string;
  senhaAtual?:string;
  novaSenha?:string;

  constructor(values: UsuarioRecuperaSenha) {
      Object.assign(this, values);
  }
}
