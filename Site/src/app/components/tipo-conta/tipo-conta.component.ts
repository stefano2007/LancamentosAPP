import { TipoConta } from './../../../model/TipoConta';
import { Component, Input, OnInit } from '@angular/core';
import { TipoContaService } from 'src/service/TipoContaService';

@Component({
  selector: 'app-tipo-conta',
  templateUrl: './tipo-conta.component.html',
  styleUrls: ['./tipo-conta.component.css']
})
export class TipoContaComponent implements OnInit {

  constructor(private _service:TipoContaService) { }

  @Input()
  idSelected?: any;

  busca: string = "";
  somenteAtivo: boolean= false;

  lista : TipoConta[] = [];
  listaFiltro : TipoConta[] = [];

  tipoConta: TipoConta={};

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

  async BuscarPorId(id : string){
    this.buscando = true;
    let data = await this._service.getFind(id);
    console.log(data);

    this.buscando = false;
  }

  filtroLista(){
    this.listaFiltro =  this.lista.filter((l) => {
      return (l.descricao?.toLowerCase()
              .includes(this.busca.toLowerCase()) || this.busca =="")
              &&(l.ativo == this.somenteAtivo || !this.somenteAtivo);
    })
  }
}
