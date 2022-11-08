import { TipoConta } from './../../../model/TipoConta';
import { Component, OnInit } from '@angular/core';
import { TipoContaService } from 'src/service/TipoContaService';

@Component({
  selector: 'app-tipo-conta',
  templateUrl: './tipo-conta.component.html',
  styleUrls: ['./tipo-conta.component.css']
})
export class TipoContaComponent implements OnInit {

  constructor(private _service:TipoContaService) { }

  lista : TipoConta[] = [];

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
