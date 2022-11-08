import { Usuario } from './Usuario';
import { TipoConta } from './TipoConta';

export class Conta {
  id?: number;
  tipoContaId?:number;
  tipoConta?:TipoConta;
  usuarioId?:number;
  usuario?:Usuario;
  nome?: string;
  diaFechamentoFatura?: number;
  diaVencimentoFatura?: number;
  saldoAtual?: number;
  dataCriacao?: Date;
  ativo?: boolean;

  constructor(values: Conta) {
      Object.assign(this, values);
  }
}
