import { Component, Input, OnInit } from '@angular/core';
import { TipoLancamento } from 'src/model/TipoLancamento';
import { TipoLancamentoService } from 'src/service/TipoLancamentoService';

@Component({
  selector: 'app-tipo-lancamento',
  templateUrl: './tipo-lancamento.component.html',
  styleUrls: ['./tipo-lancamento.component.css']
})
export class TipoLancamentoComponent implements OnInit {

  @Input()
  idSelected?: any;

  constructor(private _service:TipoLancamentoService) { }

  lista : TipoLancamento[] = [];

  buscando: boolean = false;

  ngOnInit(): void {
     this.CarregarTodos();
  }

  async CarregarTodos()
  {
    this.buscando = true;
    this.lista = await this._service.getAll();
    console.log(this.lista);
    this.buscando = false;
  }

  async BuscarPorId(id : string){
    this.buscando = true;
    let data = await this._service.getFind(id);
    console.log(data);

    this.buscando = false;
  }
}
