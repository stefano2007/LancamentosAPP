import { Conta } from 'src/model/Conta';
import { ContaService } from 'src/service/ContaService';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-lista-conta',
  templateUrl: './lista-conta.component.html',
  styleUrls: ['./lista-conta.component.css']
})
export class ListaContaComponent implements OnInit {

  constructor(private _service:ContaService) { }

  @Input()
  idSelected?: any;

  busca: string = "";
  somenteAtivo: boolean= false;

  lista : Conta[] = [];
  listaFiltro : Conta[] = [];

  buscando: boolean = false;

  ngOnInit(): void {
     this.CarregarTodos();
  }

  async CarregarTodos()
  {
    this.buscando = true;
    this.lista = await this._service.getAll();
    this.listaFiltro = this.lista;
    this.buscando = false;
  }

}
