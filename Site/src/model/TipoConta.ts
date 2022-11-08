export class TipoConta {
  id?: number;
  descricao?: string;
  classIcone?: string;
  dataCriacao?: Date;
  ativo?: boolean;

  constructor(values: TipoConta) {
      Object.assign(this, values);
  }
}
