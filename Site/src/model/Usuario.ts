export class Usuario {
  id?: number;
  nome?: string;
  sobrenome?: string;
  email?: string;
  //login?: string;
  dataNascimento?: Date;
  celular?: string;
  profissao?: string;
  receberNoficacoesPorEmail?: boolean;
  dataCriacao?: Date;
  ativo?: boolean;

  constructor(values: Usuario) {
      Object.assign(this, values);
  }
}
