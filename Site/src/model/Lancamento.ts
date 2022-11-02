import { Usuario } from "./Usuario";
import { TipoLancamento } from "./TipoLancamento";

export class Lancamento{
  usuarioId?: number;
  usuario?: Usuario;
  id?: number;
  tipoLancamentoId?: number;
  tipoLancamento?: TipoLancamento;
  data?: Date;
  descricao?: Date;
  valor?: number;
  isLancamentoRecorrente?: boolean;
  dataCriacao?: Date;
  ativo?: boolean;

  constructor(values: Lancamento) {
    Object.assign(this, values);
}
}
