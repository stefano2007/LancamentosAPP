export class UsuarioInsert {
  nome?: string;
  sobrenome?: string;
  email?: string;
  senha?: string;
  dataNascimento?: Date;
  celular?: string;
  profissao?: string;
  receberNoficacoesPorEmail?: boolean;

  constructor(values: UsuarioInsert) {
      Object.assign(this, values);
  }
}
