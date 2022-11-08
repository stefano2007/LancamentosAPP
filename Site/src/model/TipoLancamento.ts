export class TipoLancamento {
  id?: number;
  descricao?: string;
  isDespesas?: boolean;
  classIcone?: string;
  dataCriacao?: Date;
  ativo?: boolean;

  constructor(values: TipoLancamento) {
      Object.assign(this, values);
  }
}
